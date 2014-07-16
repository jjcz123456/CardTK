using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

using FluorineFx.AMF3;

using com.pokertk.data.vo;
using com.core.battle.bo;
using com.core.battle.board;
using CardTK.Net;
using CardTK.Confs;
using com.core.battle.round;
using CardTK.Components;
using com.core.battle.player;

//using Newtonsoft.Json.Linq;




namespace CardTK.Controller
{

    public enum OptType
    {
        /// <summary>
        /// 飘窗
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 过牌
        /// </summary>
        SKIP = 1,
        /// <summary>
        /// 武将技
        /// </summary>
        MAJORSKILL = 2,
        /// <summary>
        /// 出牌
        /// </summary>
        PLAYAHAND = 4,
        /// <summary>
        /// 发牌
        /// </summary>
        FILLHAND = 8
    }




    class Test : MonoBehaviour
    {

        //public Font font;

        public static Dictionary<string, Action<object>> CallBackEvents = new Dictionary<string, Action<object>>();
        public static Dictionary<string, Action<object>> NotifyEvents = new Dictionary<string, Action<object>>();



        private BattleResultBo _currentBRB;


        private bool _canOpt;


        private List<PokerMono> _boardPokers;


        private PlayerMono _opponent;

        private PlayerMono _self;


        private Queue<string> _todoQue;

        private Dictionary<string, Action> _todoDic;


        private GameObject _board;





        private bool IsMe()
        {
            return _currentBRB.halfRound.atk.pType == 0 &&
                     _currentBRB.halfRound.atk.pId == SessionInfo._currentSysUserVO.suId;
        }



        void Awake()
        {

            CreateTestCommponent("登陆", new Vector3(-Screen.width * 0.4f, Screen.height * 0.36f), OnLoginClick);

            CreateTestCommponent("匹配", new Vector3(-Screen.width * 0.4f, Screen.height * 0.24f), OnMatchClick);


            CreateTestCommponent("出牌", new Vector3(Screen.width * 0.4f, Screen.height * 0.36f), OnMatchClick);

            CreateTestCommponent("过牌", new Vector3(Screen.width * 0.4f, Screen.height * 0.24f), OnMatchClick);



            InitEnv();

        }


        void Update()
        {
            while (_todoQue.Count > 0)
            {
                var cmd = _todoQue.Dequeue();

                _todoDic[cmd]();

            }
        }


        void InitEnv()
        {
            CallBackEvents.Add(Conf.USER_FACADE + "#" + Conf.LOGIN_ACCOUNT,
                data =>
                {
                    var vo = data as SysUserVO;

                    //var vo = JObject.FromObject(data).ToObject<SysUserVO>();

                    if (vo != null)
                    {
                        Debug.Log("login success");
                        SessionInfo._currentSysUserVO = vo;
                    }
                    else
                    {
                        Debug.Log("login failed");
                    }
                });

            //CallBackEvents.Add(Conf.PK_MATCH_FACADE + "#" + Conf.AUTO_MATCH, 
            //    data => 
            //    {

            //    });


            NotifyEvents.Add(Conf.BATTLE_MATCH_SUCCESS,
                data =>
                {
                    Debug.Log("Match success");
                    //切换到战斗界面

                    //然后发送UIReady
                    NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.UI_READY, null);
                });
            NotifyEvents.Add(Conf.BATTLE_INIT_DONE,
                data =>
                {
                    var bro = data as BattleResultBo;
                    if (bro != null)
                    {
                        Debug.Log("BattleInitDone...");
                        _currentBRB = bro;
                        _todoQue.Enqueue(Conf.BATTLE_INIT_DONE);
                    }
                });

            NotifyEvents.Add(Conf.BATTLE_TIME_IN,
                data =>
                {
                    _todoQue.Enqueue(Conf.BATTLE_TIME_IN);
                });


            NotifyEvents.Add(Conf.BATTLE_OPT_DONE,
                data =>
                {
                    var bro = data as BattleResultBo;
                    if (bro != null)
                    {
                        _currentBRB = bro;
                        //播放操作...
                        _todoQue.Enqueue(Conf.BATTLE_OPT_DONE);
                    }
                });


            NotifyEvents.Add(Conf.BATTLE_OVER_TIME,
                data =>
                {
                    _todoQue.Enqueue(Conf.BATTLE_OVER_TIME);

                });

            _todoQue = new Queue<string>();

            _todoDic = new Dictionary<string, Action>();

            //战斗初始化
            _todoDic.Add(Conf.BATTLE_INIT_DONE, () =>
            {
                for (int i = 0; i < _currentBRB.halfRound.boardPokers.Count; i++)
                {
                    //_boardPokers[i].Poker = _currentBRB.halfRound.boardPokers[i];

                    _boardPokers[_currentBRB.halfRound.boardPokers[i].pos - 1].Poker = 
                        _currentBRB.halfRound.boardPokers[i];

                }

                if (IsMe())
                {
                    _self.Player = _currentBRB.halfRound.atk;
                    _opponent.Player = _currentBRB.halfRound.def;
                }
                else
                {
                    _self.Player = _currentBRB.halfRound.def;
                    _opponent.Player = _currentBRB.halfRound.atk;
                }

                _self.NameLabel.text = _self.Player.pName;
                _opponent.NameLabel.text = _opponent.Player.pName;

                _self.HPLable.text =  _self.Player.pHp + "/" +  _self.Player.pHpMax;
                _opponent.HPLable.text = _opponent.Player.pHp + "/" + _opponent.Player.pHpMax;



                //完成后发送AnimReady
                NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.ANIM_READY, null);
            });

            //战斗主消息
            _todoDic.Add(Conf.BATTLE_OPT_DONE, () =>
            {
                //_currentBRB.halfRound.detailMfs[0].opt
                for (int i = 0; i < _currentBRB.halfRound.detailMfs.Count; i++)
                {
                    var op = _currentBRB.halfRound.detailMfs[i].opt;
                    //Debug.Log(1);                   
                    
                    var itsyou = op.optOr.pType == 0 && op.optOr.pId == SessionInfo._currentSysUserVO.suId;

                    Debug.Log("odMfs Count" + _currentBRB.halfRound.detailMfs[i].odMfs.Count);
                    for (int j = 0; j < _currentBRB.halfRound.detailMfs[i].odMfs.Count; j++)
                    {
                        var odmf = _currentBRB.halfRound.detailMfs[i].odMfs[j];
                        
                        if (itsyou)
                        {
                            _self.Player.pHp += odmf.hpMf;
                            _self.HPLable.text = _self.Player.pHp + "/" + _self.Player.pHpMax;
                        }
                        else
                        {                            
                             _opponent.Player.pHp += odmf.hpMf;
                             _opponent.HPLable.text = _opponent.Player.pHp + "/" + _opponent.Player.pHpMax;
                        }


                    }

                    switch (op.optType)
                    {
                        case OptType.NONE:
                            Debug.Log("飘窗");

                            if (_currentBRB.halfRound.round == 1)
                            {
                                //第一回合重置棋盘
                                _boardPokers[_currentBRB.halfRound.boardPokers[i].pos - 1].Poker =
                                    _currentBRB.halfRound.boardPokers[i];
                            }


                            break;
                        case OptType.SKIP:
                            Debug.Log("跳过");
                            break;
                        case OptType.MAJORSKILL:
                            Debug.Log("武将技");
                            break;
                        case OptType.PLAYAHAND:
                            

                            if (itsyou)
                            {

                            }
                            else
                            {
                                Debug.Log("敌方出牌");
                                for (int j = 0; j < op.lineOpt.pokerLines.Count; j++)
                                {
                                    //Debug.Log("from: " + op.lineOpt.pokerLines[j].from + " to: " + op.lineOpt.pokerLines[j].to);


                                }

                                for (int j = 0; j < op.lineOpt.pokerMfs.Count; j++)
                                {
                                    //Debug.Log("handpos: " + op.lineOpt.pokerMfs[j].handPoker.pos + " etype: " + op.lineOpt.pokerMfs[j].handPoker.elementType);

                                    var ophp = _opponent.HandPokers[op.lineOpt.pokerMfs[j].handPoker.pos - 1];
                                    var bdp = _boardPokers[op.lineOpt.pokerMfs[j].boardPos - 1];
                                    //bdp.gameObject.SetActive(false);
                                    //ophp.transform.parent = _board.transform;
                                    //ophp.transform.localPosition = bdp.transform.localPosition;

                                    bdp.Poker = ophp.Poker;
                                    ophp.Poker = null;


                                }

                            }

                            break;
                        case OptType.FILLHAND:

                            if (itsyou)
                            {
                                Debug.Log("玩家补牌");
                                for (int j = 0; j < op.lineOpt.pokerMfs.Count; j++)
                                {
                                    //Debug.Log( op.lineOpt.pokerMfs[j].handPoker.pos);

                                    //Debug.Log(_self.HandPokers[op.lineOpt.pokerMfs[j].handPoker.pos - 1].transform.parent.name);
                                    var shp = _self.HandPokers[op.lineOpt.pokerMfs[j].handPoker.pos - 1];

                                    shp.Reset();
                                    shp.Poker = op.lineOpt.pokerMfs[j].handPoker;
                                    shp.gameObject.SetActive(true);


                                }


                            }
                            else
                            {
                                Debug.Log("敌方补牌");
                                for (int j = 0; j < op.lineOpt.pokerMfs.Count; j++)
                                {
                                    //Debug.Log(op.lineOpt.pokerMfs[j].handPoker.pos);
                                    var shp = _opponent.HandPokers[op.lineOpt.pokerMfs[j].handPoker.pos - 1];

                                    shp.Reset();
                                    shp.Poker = op.lineOpt.pokerMfs[j].handPoker;
                                    shp.gameObject.SetActive(true);

                                }
                            }

                            break;
                        default:
                            break;
                    }





                }

                if (_currentBRB.halfRound.gameOver) 
                {
                    Debug.Log("Game Over");
                }
                else
                {
                    //完成后发送AnimReady
                    NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.ANIM_READY, null);
                }

                
            });

            //战斗计时开始
            _todoDic.Add(Conf.BATTLE_TIME_IN, () =>
            {
                if (IsMe())
                {
                    Debug.Log("玩家回合开始");
                    _self.HandPokers.ForEach(d =>
                    {
                        if (d.Poker != null)
                        {
                            d.collider2D.enabled = true;
                        }

                        //d.GetComponent<DragItem>().Reset();


                    });


                }
                else
                {
                    Debug.Log("敌方回合开始");



                }
            });

            //战斗超时
            _todoDic.Add(Conf.BATTLE_OVER_TIME, () =>
            {
                _canOpt = false;
                _self.HandPokers.ForEach(d => d.collider2D.enabled = false);
            });











            _board = NGUITools.AddChild(gameObject);
            _board.name = "board";

            //初始化棋盘
            _boardPokers = new List<PokerMono>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var go = CreateTestCommponent(_board, "空", new Vector3(Screen.width * -0.2f +
                        Screen.width * j * 0.1f, Screen.height * 0.24f - Screen.height * i * 0.12f), true);

                    var pm = go.AddComponent<PokerMono>();
                    pm.Label = go.GetComponent<UILabel>();
                    _boardPokers.Add(pm);

                }
            }


            //初始化玩家
            var p = NGUITools.AddChild(gameObject);
            p.name = "player";
            _self = p.AddComponent<PlayerMono>();

            var name = CreateTestCommponent(p, "P1", Vector3.zero, false);

            var hp = CreateTestCommponent(p, "100", new Vector3(0, -Screen.height * 0.12f), false);
            _self.NameLabel = name.GetComponent<UILabel>();
            _self.HPLable = hp.GetComponent<UILabel>();

            _self.HandPokers = new List<PokerMono>();
            for (int i = 0; i < 5; i++)
            {
                var oriPos = new Vector3(-Screen.width * 0.1f + Screen.width * i * 0.05f,
                    -Screen.height * 0.24f);
                var handp = CreateTestCommponent(p, "空", oriPos, true);

                var pkm = handp.AddComponent<PokerMono>();
                pkm.Label = handp.GetComponent<UILabel>();
                pkm.OriPos = oriPos;
                pkm.OriParent = p.transform;


                var ut = GetComponent<UIRoot>();

                var di = handp.AddComponent<DragItem>();
                di.UT = ut;
                di.PM = pkm;

                di.OnDragStart = () =>
                {
                    //Debug.Log("drag start");
                    //取出第一张
                    if (_self.FirstP != null)
                    {
                        //确定是否在牌桌上
                        if (di.transform.parent != pkm.OriParent)
                        {
                            //_self.FirstP.gameObject.SetActive(true);
                            _boardPokers[_self.FirstP.InTablePos - 1].gameObject.SetActive(true);
                            _self.FirstP = null;
                        }
                    }
                };

                //var posT1 = new int[] { 1, 5, 21, 25 };
                var posT2 = new int[] { 2, 3, 4, 22, 23, 24 };
                var posT3 = new int[] { 6, 10, 11, 15, 16, 20, };

                di.OnDropOnTable = go =>
                {
                    //牌桌上的牌
                    var pt = go.GetComponent<PokerMono>();
                    //手牌
                    var ph = di.GetComponent<PokerMono>();
                    if (pt.Poker.valid)
                    {
                        pkm.Reset();
                    }
                    else
                    {
                        //放第一张
                        if (_self.FirstP == null)
                        {
                            _self.FirstP = ph;
                            _self.FirstP.InTablePos = pt.Poker.pos;

                            Debug.Log("FirstP in Table:" + _self.FirstP.InTablePos);
                            go.SetActive(false);

                            di.transform.parent = go.transform.parent;
                            di.transform.localPosition = go.transform.localPosition;

                            di.collider2D.enabled = true;
                        }
                        //放第二张
                        else
                        {
                            //Debug.Log("lololo");
                            //Debug.Log(_self.FirstP.Poker.pos);
                            var p1 = _self.FirstP.InTablePos;
                            var p2 = pt.Poker.pos;
                            var ok = false;
                            if ((p1 == 1 && p2 == 25) || (p1 == 25 && p2 == 1) ||
                                (p1 == 5 && p2 == 21) || (p1 == 21 && p2 == 5))
                            {
                                //Debug.Log("T1 OK");
                                ok = true;
                            }

                            else if (posT2.Contains(p1) && (p2 == p1 + 20 || p2 == p1 - 20))
                            {

                                //Debug.Log("T2 OK");
                                ok = true;


                            }

                            else if (posT3.Contains(p1) && ((p2 < p1 && p2 == p1 - 4) || (p2 > p1 && p2 == p1 + 4)))
                            {

                                ok = true;
                                if (p1 == 6 && p2 == 2)
                                {
                                    ok = false;
                                }
                                //if (ok) Debug.Log("T3 OK");               

                            }

                            if (ok)
                            {
                                _self.SecondP = ph;
                                _self.SecondP.InTablePos = pt.Poker.pos;                                
                                
                                
                                var bp1 = _boardPokers[_self.FirstP.InTablePos - 1];
                                bp1.Poker = _self.FirstP.Poker;
                                bp1.gameObject.SetActive(true);

                                
                                var bp2 = _boardPokers[_self.SecondP.InTablePos - 1];
                                bp2.Poker = _self.SecondP.Poker;

                                //Debug.Log("lasdoasd: " + _self.HandPokers.Any(g => !g.gameObject.activeSelf));

                                ArrayCollection pokers = new ArrayCollection();
                                pokers.Add(new PokerMf() { boardPos = p1, handPoker = _self.FirstP.Poker });
                                pokers.Add(new PokerMf() { boardPos = p2, handPoker = ph.Poker });

                                Hashtable ht = new Hashtable()
                                {
                                    {Conf.OPT_TOKEN, _currentBRB.halfRound.lastOpt.optToken},
                                    {Conf.OPT_TYPE,(int)OptType.PLAYAHAND},
                                    {Conf.HAND_POKERS,pokers}
                                };

                                NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.DO_OPT, ht);




                                //重置
                                _self.FirstP.Reset();
                                _self.SecondP.Reset();
                                _self.FirstP.Poker = _self.SecondP.Poker = null;
                                _self.FirstP = _self.SecondP = null;

                                _canOpt = false;
                                _self.HandPokers.ForEach(d => d.collider2D.enabled = false);

                                

                            }
                            else
                            {
                                Debug.Log("wrong put");
                                pkm.Reset();
                            }

                        }
                    }
                };

                handp.collider2D.enabled = false;

                _self.HandPokers.Add(pkm);

            }


            p.transform.localPosition = new Vector3(-Screen.width * 0.38f, 0);





            //对手
            p = NGUITools.AddChild(gameObject);
            p.name = "opponent";
            _opponent = p.AddComponent<PlayerMono>();

            name = CreateTestCommponent(p, "P2", Vector3.zero, false);

            hp = CreateTestCommponent(p, "100", new Vector3(0, -Screen.height * 0.12f), false);
            _opponent.NameLabel = name.GetComponent<UILabel>();
            _opponent.HPLable = hp.GetComponent<UILabel>();
            _opponent.HandPokers = new List<PokerMono>();
            for (int i = 0; i < 5; i++)
            {
                var oriPos = new Vector3(-Screen.width * 0.1f + Screen.width * i * 0.05f,
                     -Screen.height * 0.24f);
                var handp = CreateTestCommponent(p, "空", oriPos, true);
                var pkm = handp.AddComponent<PokerMono>();
                pkm.Label = handp.GetComponent<UILabel>();
                handp.collider2D.enabled = false;


                _opponent.HandPokers.Add(pkm);

            }


            p.transform.localPosition = new Vector3(Screen.width * 0.38f, 0);




            _canOpt = false;
        }



        GameObject CreateTestCommponent(string text, Vector3 pos, UIEventListener.VoidDelegate call)
        {
            var go = NGUITools.AddChild(gameObject);
            go.name = "go";
            var ul = go.AddComponent<UILabel>();
            ul.trueTypeFont = CommonRes.FontA;
            ul.overflowMethod = UILabel.Overflow.ResizeFreely;
            ul.fontSize = 40;
            ul.depth = 10;
            ul.text = text;


            var bc = go.AddComponent<BoxCollider2D>();
            bc.isTrigger = true;
            bc.size = new Vector2(ul.width, ul.height);

            go.transform.localPosition = pos;

            UIEventListener.Get(go).onClick = call;
            return go;

        }



        GameObject CreateTestCommponent(GameObject par, string text, Vector3 pos, UIEventListener.VoidDelegate call)
        {
            var go = NGUITools.AddChild(par);
            go.name = "go";
            var ul = go.AddComponent<UILabel>();
            ul.trueTypeFont = CommonRes.FontA;
            ul.overflowMethod = UILabel.Overflow.ResizeFreely;
            ul.fontSize = 40;
            ul.depth = 10;
            ul.text = text;


            var bc = go.AddComponent<BoxCollider2D>();
            bc.isTrigger = true;
            bc.size = new Vector2(ul.width, ul.height);

            go.transform.localPosition = pos;


            UIEventListener.Get(go).onClick = call;

            return go;

        }

        GameObject CreateTestCommponent(GameObject par, string text, Vector3 pos, bool c2d)
        {
            var go = NGUITools.AddChild(par);
            go.name = "go";
            var ul = go.AddComponent<UILabel>();
            ul.trueTypeFont = CommonRes.FontA;
            ul.overflowMethod = UILabel.Overflow.ResizeFreely;
            ul.fontSize = 40;
            ul.depth = 10;
            ul.text = text;

            if (c2d)
            {
                var bc = go.AddComponent<BoxCollider2D>();
                bc.isTrigger = true;
                bc.size = new Vector2(ul.width, ul.height);
            }

            go.transform.localPosition = pos;
            return go;

        }


        void OnLoginClick(GameObject go)
        {
            Debug.Log("Login......");
            go.GetComponent<BoxCollider2D>().enabled = false;
            Hashtable ht = new Hashtable()
            {
                {Conf.ACCOUNT_NAME, "super1"},
                {Conf.ACCOUNT_PASSWORD, ""}
            };

            NetCtrl.SocketClient.Send(Conf.USER_FACADE, Conf.LOGIN_ACCOUNT, ht);

        }

        void OnMatchClick(GameObject go)
        {
            Debug.Log("Match......");
            go.GetComponent<BoxCollider2D>().enabled = false;
            NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.AUTO_MATCH, null);


        }


        void OnPlayHandClick(GameObject go)
        {

            if (_canOpt)
            {
                Debug.Log("PlayHand......");
                go.GetComponent<BoxCollider2D>().enabled = false;

                //NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.AUTO_MATCH, null);

            }


        }


        void OnSkipClick(GameObject go)
        {
            if (_canOpt)
            {
                Debug.Log("Skip......");
                go.GetComponent<BoxCollider2D>().enabled = false;


                //NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.AUTO_MATCH, null);
            }




        }








        /// <summary>
        /// 落第二张牌的时候调用，发送出牌消息
        /// </summary>
        void OnPlayHand(int pos1, int pos2, Poker p1, Poker p2)
        {
            var pokers = new List<PokerMf>()
            {
                new PokerMf(){boardPos = pos1,handPoker=p1},
                new PokerMf(){boardPos = pos2,handPoker = p2}
            };

            Hashtable ht = new Hashtable()
            {
                {Conf.OPT_TOKEN, _currentBRB.halfRound.lastOpt.optToken},
                {Conf.OPT_TYPE,(int)OptType.PLAYAHAND},
                {Conf.HAND_POKERS,pokers}
            };



            NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.DO_OPT, ht);
        }

        /// <summary>
        /// 过牌
        /// </summary>
        void Skip()
        {
            Hashtable ht = new Hashtable()
            {
                {Conf.OPT_TOKEN, _currentBRB.halfRound.lastOpt.optToken},
                {Conf.OPT_TYPE,(int)OptType.SKIP}
                
            };
            NetCtrl.SocketClient.Send(Conf.PK_MATCH_FACADE, Conf.DO_OPT, ht);
        }







    }
}
