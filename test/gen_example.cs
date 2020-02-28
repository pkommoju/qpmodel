/*
--- plan ---
PhysicLimit (2) (actual rows=0)
    Output: {a.a2}[0]*2,{count(a.a1)}[1],repeat('a',{a.a2}[0])
    -> PhysicHashAgg  (actual rows=0)
        Output: {a.a2}[0]*2,{count(a.a1)}[1],repeat('a',{a.a2}[0])
        Aggregates: count(a.a1[0])
        Group by: a.a2[1]
        -> PhysicHashJoin  (actual rows=0)
            Output: a.a1[0],a.a2[1]
            Filter: a.a1[0]=b.b1[2]
            -> PhysicHashJoin  (actual rows=0)
                Output: a.a1[0],a.a2[1]
                Filter: a.a2[1]=c.c2[2]
                -> PhysicScanTable a (actual rows=0)
                    Output: a.a1[0],a.a2[1]
                -> PhysicScanTable c (actual rows=0)
                    Output: c.c2[1]
            -> PhysicScanTable b (actual rows=0)
                Output: b.b1[0]

*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using adb.physic;
using adb.utils;
using adb.logic;
using adb.test;
using adb.expr;
using adb.dml;

// entrance of query execution
public class QueryCode
{
    public static void Run(SQLStatement stmt, ExecContext context)
    {
        PhysicCollect PhysicCollect108 = stmt.physicPlan_.LocateNode("108") as PhysicCollect;
        PhysicProfiling PhysicProfiling109 = stmt.physicPlan_.LocateNode("109") as PhysicProfiling;
        LogicLimit LogicLimit109 = PhysicProfiling109.logic_ as LogicLimit;
        var filter109 = LogicLimit109.filter_;
        var output109 = LogicLimit109.output_;
        PhysicLimit PhysicLimit110 = stmt.physicPlan_.LocateNode("110") as PhysicLimit;
        LogicLimit LogicLimit110 = PhysicLimit110.logic_ as LogicLimit;
        var filter110 = LogicLimit110.filter_;
        var output110 = LogicLimit110.output_;
        PhysicProfiling PhysicProfiling111 = stmt.physicPlan_.LocateNode("111") as PhysicProfiling;
        LogicAgg LogicAgg111 = PhysicProfiling111.logic_ as LogicAgg;
        var filter111 = LogicAgg111.filter_;
        var output111 = LogicAgg111.output_;
        PhysicHashAgg PhysicHashAgg112 = stmt.physicPlan_.LocateNode("112") as PhysicHashAgg;
        LogicAgg LogicAgg112 = PhysicHashAgg112.logic_ as LogicAgg;
        var filter112 = LogicAgg112.filter_;
        var output112 = LogicAgg112.output_;
        PhysicProfiling PhysicProfiling113 = stmt.physicPlan_.LocateNode("113") as PhysicProfiling;
        LogicJoin LogicJoin113 = PhysicProfiling113.logic_ as LogicJoin;
        var filter113 = LogicJoin113.filter_;
        var output113 = LogicJoin113.output_;
        PhysicHashJoin PhysicHashJoin114 = stmt.physicPlan_.LocateNode("114") as PhysicHashJoin;
        LogicJoin LogicJoin114 = PhysicHashJoin114.logic_ as LogicJoin;
        var filter114 = LogicJoin114.filter_;
        var output114 = LogicJoin114.output_;
        PhysicProfiling PhysicProfiling115 = stmt.physicPlan_.LocateNode("115") as PhysicProfiling;
        LogicJoin LogicJoin115 = PhysicProfiling115.logic_ as LogicJoin;
        var filter115 = LogicJoin115.filter_;
        var output115 = LogicJoin115.output_;
        PhysicHashJoin PhysicHashJoin116 = stmt.physicPlan_.LocateNode("116") as PhysicHashJoin;
        LogicJoin LogicJoin116 = PhysicHashJoin116.logic_ as LogicJoin;
        var filter116 = LogicJoin116.filter_;
        var output116 = LogicJoin116.output_;
        PhysicProfiling PhysicProfiling117 = stmt.physicPlan_.LocateNode("117") as PhysicProfiling;
        LogicScanTable LogicScanTable117 = PhysicProfiling117.logic_ as LogicScanTable;
        var filter117 = LogicScanTable117.filter_;
        var output117 = LogicScanTable117.output_;
        PhysicScanTable PhysicScanTablea = stmt.physicPlan_.LocateNode("a") as PhysicScanTable;
        LogicScanTable LogicScanTablea = PhysicScanTablea.logic_ as LogicScanTable;
        var filtera = LogicScanTablea.filter_;
        var outputa = LogicScanTablea.output_;
        PhysicProfiling PhysicProfiling118 = stmt.physicPlan_.LocateNode("118") as PhysicProfiling;
        LogicScanTable LogicScanTable118 = PhysicProfiling118.logic_ as LogicScanTable;
        var filter118 = LogicScanTable118.filter_;
        var output118 = LogicScanTable118.output_;
        PhysicScanTable PhysicScanTablec = stmt.physicPlan_.LocateNode("c") as PhysicScanTable;
        LogicScanTable LogicScanTablec = PhysicScanTablec.logic_ as LogicScanTable;
        var filterc = LogicScanTablec.filter_;
        var outputc = LogicScanTablec.output_;
        var hm116 = new Dictionary<KeyList, List<TaggedRow>>();
        PhysicProfiling PhysicProfiling119 = stmt.physicPlan_.LocateNode("119") as PhysicProfiling;
        LogicScanTable LogicScanTable119 = PhysicProfiling119.logic_ as LogicScanTable;
        var filter119 = LogicScanTable119.filter_;
        var output119 = LogicScanTable119.output_;
        PhysicScanTable PhysicScanTableb = stmt.physicPlan_.LocateNode("b") as PhysicScanTable;
        LogicScanTable LogicScanTableb = PhysicScanTableb.logic_ as LogicScanTable;
        var filterb = LogicScanTableb.filter_;
        var outputb = LogicScanTableb.output_;
        var hm114 = new Dictionary<KeyList, List<TaggedRow>>();
        var aggrcore112 = LogicAgg112.aggrFns_;
        var hm112 = new Dictionary<KeyList, Row>();
        var nrows110 = 0;
        PhysicProfiling109.nloops_++;
        PhysicProfiling111.nloops_++;
        PhysicProfiling113.nloops_++;
        PhysicProfiling115.nloops_++;
        PhysicProfiling117.nloops_++;
        var heapa = (LogicScanTablea.tabref_).Table().heap_.GetEnumerator();
        for (;;)
        {
            Row ra = null;
            if (context.stop_)
                break;
            if (heapa.MoveNext())
                ra = heapa.Current;
            else
                break;
            {
                {
                    // projection on PhysicScanTablea: Output: a.a1[0],a.a2[1] 
                    Row rproj = new Row(2);
                    rproj[0] = ra[0];
                    rproj[1] = ra[1];
                    ra = rproj;
                }

                PhysicProfiling117.nrows_++;
                var r117 = ra;
                var keys116 = KeyList.ComputeKeys(context, LogicJoin116.leftKeys_, r117);
                if (hm116.TryGetValue(keys116, out List<TaggedRow> exist))
                {
                    exist.Add(new TaggedRow(r117));
                }
                else
                {
                    var rows = new List<TaggedRow>();
                    rows.Add(new TaggedRow(r117));
                    hm116.Add(keys116, rows);
                }
            }
        }

        if (hm116.Count == 0)
            return;
        PhysicProfiling118.nloops_++;
        var heapc = (LogicScanTablec.tabref_).Table().heap_.GetEnumerator();
        for (;;)
        {
            Row rc = null;
            if (context.stop_)
                break;
            if (heapc.MoveNext())
                rc = heapc.Current;
            else
                break;
            {
                {
                    // projection on PhysicScanTablec: Output: c.c2[1] 
                    Row rproj = new Row(1);
                    rproj[0] = rc[1];
                    rc = rproj;
                }

                PhysicProfiling118.nrows_++;
                var r118 = rc;
                if (context.stop_)
                    return;
                Row fakel116 = new Row(2);
                Row r116 = new Row(fakel116, r118);
                var keys116 = KeyList.ComputeKeys(context, LogicJoin116.rightKeys_, r116);
                bool foundOneMatch116 = false;
                if (hm116.TryGetValue(keys116, out List<TaggedRow> exist116))
                {
                    foundOneMatch116 = true;
                    foreach (var v116 in exist116)
                    {
                        r116 = new Row(v116.row_, r118);
                        {
                            // projection on PhysicHashJoin116: Output: a.a1[0],a.a2[1] 
                            Row rproj = new Row(2);
                            rproj[0] = r116[0];
                            rproj[1] = r116[1];
                            r116 = rproj;
                        }

                        PhysicProfiling115.nrows_++;
                        var r115 = r116;
                        var keys114 = KeyList.ComputeKeys(context, LogicJoin114.leftKeys_, r115);
                        if (hm114.TryGetValue(keys114, out List<TaggedRow> exist))
                        {
                            exist.Add(new TaggedRow(r115));
                        }
                        else
                        {
                            var rows = new List<TaggedRow>();
                            rows.Add(new TaggedRow(r115));
                            hm114.Add(keys114, rows);
                        }
                    }
                }
                else
                {
                // no match for antisemi
                }
            }
        }

        if (hm114.Count == 0)
            return;
        PhysicProfiling119.nloops_++;
        var heapb = (LogicScanTableb.tabref_).Table().heap_.GetEnumerator();
        for (;;)
        {
            Row rb = null;
            if (context.stop_)
                break;
            if (heapb.MoveNext())
                rb = heapb.Current;
            else
                break;
            {
                {
                    // projection on PhysicScanTableb: Output: b.b1[0] 
                    Row rproj = new Row(1);
                    rproj[0] = rb[0];
                    rb = rproj;
                }

                PhysicProfiling119.nrows_++;
                var r119 = rb;
                if (context.stop_)
                    return;
                Row fakel114 = new Row(2);
                Row r114 = new Row(fakel114, r119);
                var keys114 = KeyList.ComputeKeys(context, LogicJoin114.rightKeys_, r114);
                bool foundOneMatch114 = false;
                if (hm114.TryGetValue(keys114, out List<TaggedRow> exist114))
                {
                    foundOneMatch114 = true;
                    foreach (var v114 in exist114)
                    {
                        r114 = new Row(v114.row_, r119);
                        {
                            // projection on PhysicHashJoin114: Output: a.a1[0],a.a2[1] 
                            Row rproj = new Row(2);
                            rproj[0] = r114[0];
                            rproj[1] = r114[1];
                            r114 = rproj;
                        }

                        PhysicProfiling113.nrows_++;
                        var r113 = r114;
                        var keys = KeyList.ComputeKeys(context, LogicAgg112.keys_, r113);
                        if (hm112.TryGetValue(keys, out Row exist))
                        {
                            for (int i = 0; i < 1; i++)
                            {
                                var old = exist[i];
                                exist[i] = aggrcore112[i].Accum(context, old, r113);
                            }
                        }
                        else
                        {
                            hm112.Add(keys, PhysicHashAgg112.AggrCoreToRow(r113));
                            exist = hm112[keys];
                            for (int i = 0; i < 1; i++)
                                exist[i] = aggrcore112[i].Init(context, r113);
                        }
                    }
                }
                else
                {
                // no match for antisemi
                }
            }
        }

        foreach (var v112 in hm112)
        {
            if (context.stop_)
                break;
            var keys112 = v112.Key;
            Row aggvals112 = v112.Value;
            for (int i = 0; i < 1; i++)
                aggvals112[i] = aggrcore112[i].Finalize(context, aggvals112[i]);
            var r112 = new Row(keys112, aggvals112);
            if (true || LogicAgg112.having_.Exec(context, r112)is true)
            {
                {
                    // projection on PhysicHashAgg112: Output: {a.a2}[0]*2,{count(a.a1)}[1],repeat('a',{a.a2}[0]) 
                    Row rproj = new Row(3);
                    rproj[0] = ((dynamic)r112[0] * (dynamic)2);
                    rproj[1] = r112[1];
                    rproj[2] = ExprSearch.Locate("74").Exec(context, r112) /*repeat('a',{a.a2}[0])*/;
                    r112 = rproj;
                }

                PhysicProfiling111.nrows_++;
                var r111 = r112;
                nrows110++;
                Debug.Assert(nrows110 <= 2);
                if (nrows110 == 2)
                    context.stop_ = true;
                var r110 = r111;
                PhysicProfiling109.nrows_++;
                var r109 = r110;
                Row newr = new Row(3);
                newr[0] = r109[0];
                newr[1] = r109[1];
                newr[2] = r109[2];
                PhysicCollect108.rows_.Add(newr);
                Console.WriteLine(newr);
            }
        }
    }
}

/*
-- profiling plan --
compiled OK
2,1,a
4,1,aa
Total cost: 44
PhysicLimit (2) (inccost=44, cost=2, rows=2) (actual rows=2)
    Output: {a.a2}[0]*2,{count(a.a1)}[1],repeat('a',{a.a2}[0])
    -> PhysicHashAgg  (inccost=42, cost=9, rows=3) (actual rows=2)
        Output: {a.a2}[0]*2,{count(a.a1)}[1],repeat('a',{a.a2}[0])
        Aggregates: count(a.a1[0])
        Group by: a.a2[1]
        -> PhysicHashJoin  (inccost=33, cost=12, rows=3) (actual rows=3)
            Output: a.a1[0],a.a2[1]
            Filter: a.a1[0]=b.b1[2]
            -> PhysicHashJoin  (inccost=18, cost=12, rows=3) (actual rows=3)
                Output: a.a1[0],a.a2[1]
                Filter: a.a2[1]=c.c2[2]
                -> PhysicScanTable a (inccost=3, cost=3, rows=3) (actual rows=3)
                    Output: a.a1[0],a.a2[1]
                -> PhysicScanTable c (inccost=3, cost=3, rows=3) (actual rows=3)
                    Output: c.c2[1]
            -> PhysicScanTable b (inccost=3, cost=3, rows=3) (actual rows=3)
                Output: b.b1[0]
*/				