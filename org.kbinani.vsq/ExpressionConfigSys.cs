﻿/*
 * ExpressionConfigSys.cs
 * Copyright (C) 2009 kbinani
 *
 * This file is part of org.kbinani.vsq.
 *
 * org.kbinani.vsq is free software; you can redistribute it and/or
 * modify it under the terms of the BSD License.
 *
 * org.kbinani.vsq is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 */
#if JAVA
package org.kbinani.vsq;

import java.util.*;
import java.io.*;
import org.kbinani.*;
#else
using System;
using System.Text;
using org.kbinani;
using org.kbinani.java.util;
using org.kbinani.java.io;

namespace org.kbinani.vsq {
#endif

    public class ExpressionConfigSys {
#if JAVA
        private final int MAX_VIBRATO = 0x400;
#else
        private const int MAX_VIBRATO = 0x400;
#endif
        private Vector<VibratoHandle> m_vibrato_configs;
        private Vector<NoteHeadHandle> m_attack_configs;

        /*private void printTo( String file ) {
            BufferedWriter sw = null;
            try {
                sw = new BufferedWriter( new FileWriter( file ) );
                int count = 0;
                for ( Iterator itr = m_vibrato_configs.iterator(); itr.hasNext(); ) {
                    count++;
                    VibratoConfig vconfig = (VibratoConfig)itr.next();
                    String name = "v" + count;
                    sw.write( "VibratoConfig " + name + " = new VibratoConfig();" );
                    sw.newLine();
                    sw.write( name + ".author = \"" + vconfig.author + "\";" );
                    sw.newLine();
                    sw.write( name + ".file = \"" + vconfig.file + "\";" );
                    sw.newLine();
                    sw.write( name + ".number = " + vconfig.number + ";" );
                    sw.newLine();
                    sw.write( name + ".vendor = \"" + vconfig.vendor + "\";" );
                    sw.newLine();
                    sw.write( name + ".contents.IconID = \"" + vconfig.contents.IconID + "\";" );
                    sw.newLine();
                    sw.write( name + ".contents.IDS = \"" + vconfig.contents.IDS + "\";" );
                    sw.newLine();
                    sw.write( name + ".contents.Original = " + vconfig.contents.Original + ";" );
                    sw.newLine();
                    sw.write( name + ".contents.Caption = \"" + vconfig.contents.Caption + "\";" );
                    sw.newLine();
                    sw.write( name + ".contents.Length = " + vconfig.contents.getLength() + ";" );
                    sw.newLine();
                    sw.write( name + ".contents.StartDepth = " + vconfig.contents.StartDepth + ";" );
                    sw.write( name + ".contents.DepthBP = new VibratoBPList( new float[]{ " );
                    for ( int i = 0; i < vconfig.contents.DepthBP.getCount(); i++ ) {
                        sw.write( ((i > 0) ? ", " : "") + vconfig.contents.DepthBP.getElement( i ).X + "f" );
                    }
                    sw.write( " }, new int[]{ " );
                    for ( int i = 0; i < vconfig.contents.DepthBP.getCount(); i++ ) {
                        sw.write( ((i > 0) ? ", " : "") + vconfig.contents.DepthBP.getElement( i ).Y );
                    }
                    sw.write( " } );" );
                    sw.newLine();
                    sw.write( name + ".contents.StartRate = " + vconfig.contents.StartRate + ";" );
                    sw.newLine();
                    sw.write( name + ".contents.RateBP = new VibratoBPList( new float[]{ " );
                    for ( int i = 0; i < vconfig.contents.RateBP.getCount(); i++ ) {
                        sw.write( ((i > 0) ? ", " : "") + vconfig.contents.RateBP.getElement( i ).X + "f" );
                    }
                    sw.write( " }, new int[]{ " );
                    for ( int i = 0; i < vconfig.contents.RateBP.getCount(); i++ ) {
                        sw.write( ((i > 0) ? ", " : "") + vconfig.contents.RateBP.getElement( i ).Y );
                    }
                    sw.write( " } );" );
                    sw.newLine();
                    sw.write( "ret.m_vibrato_configs.add( " + name + " );" );
                    sw.newLine();
                    sw.newLine();
                }
                count = 0;

                for ( Iterator itr = m_attack_configs.iterator(); itr.hasNext(); ) {
                    count++;
                    AttackConfig aconfig = (AttackConfig)itr.next();
                    String name = "a" + count;
                    sw.write( "AttackConfig " + name + " = new AttackConfig();" );
                    sw.newLine();
                    sw.write( name + ".author = \"" + aconfig.author + "\";" );
                    sw.newLine();
                    sw.write( name + ".file = \"" + aconfig.file + "\";" );
                    sw.newLine();
                    sw.write( name + ".number = " + aconfig.number + ";" );
                    sw.newLine();
                    sw.write( name + ".vendor = \"" + aconfig.vendor + "\";" );
                    sw.newLine();
                    sw.write( name + ".contents.IconID = \"" + aconfig.contents.IconID + "\";" );
                    sw.newLine();
                    sw.write( name + ".contents.IDS = \"" + aconfig.contents.IDS + "\";" );
                    sw.newLine();
                    sw.write( name + ".contents.Original = " + aconfig.contents.Original + ";" );
                    sw.newLine();
                    sw.write( name + ".contents.Caption = \"" + aconfig.contents.Caption + "\";" );
                    sw.newLine();
                    sw.write( name + ".contents.Length = " + aconfig.contents.getLength() + ";" );
                    sw.newLine();
                    sw.write( name + ".contents.Duration = " + aconfig.contents.Duration + ";" );
                    sw.newLine();
                    sw.write( name + ".contents.Depth = " + aconfig.contents.Depth + ";" );
                    sw.newLine();
                    sw.write( "ret.m_attack_configs.add( " + name + " );" );
                    sw.newLine();
                    sw.newLine();
                }
            } catch ( Exception ex ) {
            } finally {
                if ( sw != null ) {
                    try {
                        sw.close();
                    } catch ( Exception ex2 ) {
                    }
                }
            }
        }*/

        public static ExpressionConfigSys getVocaloid1Default() {
            ExpressionConfigSys ret = new ExpressionConfigSys();
            ret.m_vibrato_configs = new Vector<VibratoHandle>();
            ret.m_attack_configs = new Vector<NoteHeadHandle>();
            VibratoHandle v1 = new VibratoHandle();
            /*v1.author = "Taro";
            v1.file = "normal.aic";
            v1.number = 1;
            v1.vendor = "YAMAHA";*/
            v1.Index = 1;
            v1.IconID = "$04040001";
            v1.IDS = "normal";
            v1.Original = 0;
            v1.setCaption( "Normal Vibrato" );
            v1.setLength( 480 );
            v1.setStartDepth( 64 );
            v1.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v1.setStartRate( 64 );
            v1.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v1 );

            VibratoHandle v2 = new VibratoHandle();
            /*v2.author = "Taro";
            v2.file = "subtle.aic";
            v2.number = 2;
            v2.vendor = "YAMAHA";*/
            v2.Index = 2;
            v2.IconID = "$04040002";
            v2.IDS = "normal";
            v2.Original = 0;
            v2.setCaption( "Subtle Vibrato" );
            v2.setLength( 480 );
            v2.setStartDepth( 32 );
            v2.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v2.setStartRate( 56 );
            v2.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v2 );

            VibratoHandle v3 = new VibratoHandle();
            /*v3.author = "Taro";
            v3.file = "slight.aic";
            v3.number = 3;
            v3.vendor = "YAMAHA";*/
            v3.Index = 3;
            v3.IconID = "$04040003";
            v3.IDS = "slight";
            v3.Original = 0;
            v3.setCaption( "Slight Vibrato" );
            v3.setLength( 480 );
            v3.setStartDepth( 32 );
            v3.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v3.setStartRate( 64 );
            v3.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v3 );

            VibratoHandle v4 = new VibratoHandle();
            /*v4.author = "Taro";
            v4.file = "deep.aic";
            v4.number = 4;
            v4.vendor = "YAMAHA";*/
            v4.Index = 4;
            v4.IconID = "$04040004";
            v4.IDS = "deep";
            v4.Original = 0;
            v4.setCaption( "Deep Vibrato" );
            v4.setLength( 480 );
            v4.setStartDepth( 64 );
            v4.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v4.setStartRate( 64 );
            v4.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v4 );

            VibratoHandle v5 = new VibratoHandle();
            /*v5.author = "Taro";
            v5.file = "verydeep.aic";
            v5.number = 5;
            v5.vendor = "YAMAHA";*/
            v5.Index = 5;
            v5.IconID = "$04040005";
            v5.IDS = "extreme";
            v5.Original = 0;
            v5.setCaption( "Very Deep Vibrato" );
            v5.setLength( 480 );
            v5.setStartDepth( 64 );
            v5.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v5.setStartRate( 120 );
            v5.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v5 );

            VibratoHandle v6 = new VibratoHandle();
            /*v6.author = "Taro";
            v6.file = "extreme.aic";
            v6.number = 6;
            v6.vendor = "YAMAHA";*/
            v6.Index = 6;
            v6.IconID = "$04040006";
            v6.IDS = "extreme";
            v6.Original = 0;
            v6.setCaption( "Extreme Vibrato (like Japanese Enka)" );
            v6.setLength( 480 );
            v6.setStartDepth( 64 );
            v6.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v6.setStartRate( 64 );
            v6.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v6 );

            NoteHeadHandle a1 = new NoteHeadHandle();
            /*a1.author = "Taro";
            a1.file = "na_tenuto.aic";
            a1.number = 1;
            a1.vendor = "YAMAHA";*/
            a1.Index = 1;
            a1.IconID = "$01010001";
            a1.IDS = "tenuto";
            a1.Original = 0;
            a1.setCaption( "Tenuto" );
            a1.setLength( 120 );
            a1.setDuration( 64 );
            a1.setDepth( 64 );
            ret.m_attack_configs.add( a1 );

            NoteHeadHandle a2 = new NoteHeadHandle();
            /*a2.author = "Taro";
            a2.file = "na_accent.aic";
            a2.number = 2;
            a2.vendor = "YAMAHA";*/
            a2.Index = 2;
            a2.IconID = "$01010002";
            a2.IDS = "accent";
            a2.Original = 0;
            a2.setCaption( "Accent" );
            a2.setLength( 120 );
            a2.setDuration( 64 );
            a2.setDepth( 64 );
            ret.m_attack_configs.add( a2 );

            NoteHeadHandle a3 = new NoteHeadHandle();
            /*a3.author = "Taro";
            a3.file = "na_extreme_accent.aic";
            a3.number = 3;
            a3.vendor = "YAMAHA";*/
            a3.Index = 3;
            a3.IconID = "$01010003";
            a3.IDS = "accent_extreme";
            a3.Original = 0;
            a3.setCaption( "Extreme Accent" );
            a3.setLength( 120 );
            a3.setDuration( 64 );
            a3.setDepth( 64 );
            ret.m_attack_configs.add( a3 );

            NoteHeadHandle a4 = new NoteHeadHandle();
            /*a4.author = "Taro";
            a4.file = "na_legato.aic";
            a4.number = 4;
            a4.vendor = "YAMAHA";*/
            a4.Index = 4;
            a4.IconID = "$01010004";
            a4.IDS = "legato";
            a4.Original = 0;
            a4.setCaption( "Legato" );
            a4.setLength( 120 );
            a4.setDuration( 64 );
            a4.setDepth( 64 );
            ret.m_attack_configs.add( a4 );

            NoteHeadHandle a5 = new NoteHeadHandle();
            /*a5.author = "Taro";
            a5.file = "na_fast_bendup.aic";
            a5.number = 5;
            a5.vendor = "YAMAHA";*/
            a5.Index = 5;
            a5.IconID = "$01010005";
            a5.IDS = "bendup_fast";
            a5.Original = 0;
            a5.setCaption( "Fast Bendu" );
            a5.setLength( 120 );
            a5.setDuration( 64 );
            a5.setDepth( 64 );
            ret.m_attack_configs.add( a5 );

            NoteHeadHandle a6 = new NoteHeadHandle();
            /*a6.author = "Taro";
            a6.file = "na_slow_bendup.aic";
            a6.number = 6;
            a6.vendor = "YAMAHA";*/
            a6.Index = 6;
            a6.IconID = "$01010006";
            a6.IDS = "bendup_slow";
            a6.Original = 0;
            a6.setCaption( "Slow Bendup" );
            a6.setLength( 120 );
            a6.setDuration( 64 );
            a6.setDepth( 64 );
            ret.m_attack_configs.add( a6 );

            NoteHeadHandle a7 = new NoteHeadHandle();
            /*a7.author = "Taro";
            a7.file = "na_trill_semi.aic";
            a7.number = 7;
            a7.vendor = "YAMAHA";*/
            a7.Index = 7;
            a7.IconID = "$01010007";
            a7.IDS = "trill_semi";
            a7.Original = 0;
            a7.setCaption( "Trill Semitone" );
            a7.setLength( 120 );
            a7.setDuration( 64 );
            a7.setDepth( 64 );
            ret.m_attack_configs.add( a7 );

            NoteHeadHandle a8 = new NoteHeadHandle();
            /*a8.author = "Taro";
            a8.file = "na_trill_whole.aic";
            a8.number = 8;
            a8.vendor = "YAMAHA";*/
            a8.Index = 8;
            a8.IconID = "$01010008";
            a8.IDS = "trill_whole";
            a8.Original = 0;
            a8.setCaption( "Trill Wholetone" );
            a8.setLength( 120 );
            a8.setDuration( 64 );
            a8.setDepth( 64 );
            ret.m_attack_configs.add( a8 );

            NoteHeadHandle a9 = new NoteHeadHandle();
            /*a9.author = "Taro";
            a9.file = "na_mordent_semi.aic";
            a9.number = 9;
            a9.vendor = "YAMAHA";*/
            a9.Index = 9;
            a9.IconID = "$01010009";
            a9.IDS = "mordent_semi";
            a9.Original = 0;
            a9.setCaption( "Mordent Semitone" );
            a9.setLength( 120 );
            a9.setDuration( 64 );
            a9.setDepth( 64 );
            ret.m_attack_configs.add( a9 );

            NoteHeadHandle a10 = new NoteHeadHandle();
            /*a10.author = "Taro";
            a10.file = "na_mordent_whole.aic";
            a10.number = 10;
            a10.vendor = "YAMAHA";*/
            a10.Index = 10;
            a10.IconID = "$0101000a";
            a10.IDS = "mordent_whole";
            a10.Original = 0;
            a10.setCaption( "Mordent Wholetone" );
            a10.setLength( 120 );
            a10.setDuration( 64 );
            a10.setDepth( 64 );
            ret.m_attack_configs.add( a10 );

            return ret;
        }

        public static ExpressionConfigSys getVocaloid2Default() {
            ExpressionConfigSys ret = new ExpressionConfigSys();
            ret.m_vibrato_configs = new Vector<VibratoHandle>();
            ret.m_attack_configs = new Vector<NoteHeadHandle>();
            VibratoHandle v1 = new VibratoHandle();
            /*v1.author = "Standard";
            v1.file = "normal2_type1.aic";
            v1.number = 1;
            v1.vendor = "YAMAHA";*/
            v1.Index = 1;
            v1.IconID = "$04040001";
            v1.IDS = "normal";
            v1.Original = 0;
            v1.setCaption( "[Normal] Type 1" );
            v1.setLength( 480 );
            v1.setStartDepth( 64 );
            v1.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v1.setStartRate( 50 );
            v1.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v1 );

            VibratoHandle v2 = new VibratoHandle();
            /*v2.author = "Standard";
            v2.file = "normal2_type2.aic";
            v2.number = 2;
            v2.vendor = "YAMAHA";*/
            v2.Index = 2;
            v2.IconID = "$04040002";
            v2.IDS = "normal";
            v2.Original = 0;
            v2.setCaption( "[Normal] Type 2" );
            v2.setLength( 480 );
            v2.setStartDepth( 40 );
            v2.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v2.setStartRate( 50 );
            v2.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v2 );

            VibratoHandle v3 = new VibratoHandle();
            /*v3.author = "Standard";
            v3.file = "normal2_type3.aic";
            v3.number = 3;
            v3.vendor = "YAMAHA";*/
            v3.Index = 3;
            v3.IconID = "$04040003";
            v3.IDS = "normal";
            v3.Original = 0;
            v3.setCaption( "[Normal] Type 3" );
            v3.setLength( 480 );
            v3.setStartDepth( 127 );
            v3.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v3.setStartRate( 50 );
            v3.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v3 );

            VibratoHandle v4 = new VibratoHandle();
            /*v4.author = "Standard";
            v4.file = "normal2_type4.aic";
            v4.number = 4;
            v4.vendor = "YAMAHA";*/
            v4.Index = 4;
            v4.IconID = "$04040004";
            v4.IDS = "normal";
            v4.Original = 0;
            v4.setCaption( "[Normal] Type 4" );
            v4.setLength( 480 );
            v4.setStartDepth( 64 );
            v4.setDepthBP( new VibratoBPList( new float[] { 0.6042f, 0.6125f, 0.6167f, 0.6208f, 0.625f, 0.6333f, 0.6375f, 0.6417f, 0.6458f, 0.6542f, 0.6583f, 0.6667f, 0.6708f, 0.675f, 0.6792f, 0.6833f, 0.6917f, 0.6958f, 0.7042f, 0.7083f, 0.7125f, 0.7167f, 0.7208f, 0.725f, 0.7292f, 0.7375f, 0.7458f, 0.75f, 0.7583f, 0.7625f, 0.7667f, 0.7708f, 0.775f, 0.7833f, 0.7917f, 0.7958f, 0.8f, 0.8042f, 0.8083f, 0.8125f, 0.8208f, 0.8292f, 0.8375f, 0.8417f, 0.8458f, 0.85f, 0.8542f, 0.8625f, 0.8667f, 0.875f, 0.8792f, 0.8833f, 0.8875f, 0.8917f, 0.8958f, 0.9f, 1f }, new int[] { 64, 63, 62, 61, 59, 58, 57, 56, 55, 54, 52, 51, 50, 49, 48, 47, 45, 44, 43, 42, 41, 40, 39, 38, 37, 35, 34, 32, 31, 30, 29, 28, 27, 25, 24, 23, 22, 21, 20, 19, 17, 15, 14, 13, 12, 11, 10, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 } ) );
            v4.setStartRate( 50 );
            v4.setRateBP( new VibratoBPList( new float[] { 0.6f, 0.6125f, 0.6167f, 0.6208f, 0.6292f, 0.6333f, 0.6375f, 0.6417f, 0.6542f, 0.6583f, 0.6625f, 0.6667f, 0.675f, 0.6833f, 0.6875f, 0.6917f, 0.7f, 0.7042f, 0.7083f, 0.7125f, 0.725f, 0.7292f, 0.7333f, 0.7375f, 0.7458f, 0.75f, 0.7583f, 0.7625f, 0.7708f, 0.775f, 0.7792f, 0.7833f, 0.7958f, 0.8f, 0.8042f, 0.8083f, 0.8167f, 0.8208f, 0.8292f, 0.8333f, 0.8417f, 0.8458f, 0.85f, 0.8542f, 0.8667f, 0.8708f, 0.875f, 0.8792f, 0.8875f, 0.8917f, 0.9f, 1f }, new int[] { 50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 40, 39, 38, 37, 36, 35, 34, 33, 32, 31, 30, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 } ) );
            ret.m_vibrato_configs.add( v4 );

            VibratoHandle v5 = new VibratoHandle();
            /*v5.author = "Standard";
            v5.file = "extreme2_type1.aic";
            v5.number = 5;
            v5.vendor = "YAMAHA";*/
            v5.Index = 5;
            v5.IconID = "$04040005";
            v5.IDS = "extreme";
            v5.Original = 0;
            v5.setCaption( "[Extreme] Type 1" );
            v5.setLength( 480 );
            v5.setStartDepth( 64 );
            v5.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v5.setStartRate( 64 );
            v5.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v5 );

            VibratoHandle v6 = new VibratoHandle();
            /*v6.author = "Standard";
            v6.file = "extreme2_type2.aic";
            v6.number = 6;
            v6.vendor = "YAMAHA";*/
            v6.Index = 6;
            v6.IconID = "$04040006";
            v6.IDS = "extreme";
            v6.Original = 0;
            v6.setCaption( "[Extreme] Type 2" );
            v6.setLength( 480 );
            v6.setStartDepth( 32 );
            v6.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v6.setStartRate( 32 );
            v6.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v6 );

            VibratoHandle v7 = new VibratoHandle();
            /*v7.author = "Standard";
            v7.file = "extreme2_type3.aic";
            v7.number = 7;
            v7.vendor = "YAMAHA";*/
            v7.Index = 7;
            v7.IconID = "$04040007";
            v7.IDS = "extreme";
            v7.Original = 0;
            v7.setCaption( "[Extreme] Type 3" );
            v7.setLength( 480 );
            v7.setStartDepth( 100 );
            v7.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v7.setStartRate( 50 );
            v7.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v7 );

            VibratoHandle v8 = new VibratoHandle();
            /*v8.author = "Standard";
            v8.file = "extreme2_type4.aic";
            v8.number = 8;
            v8.vendor = "YAMAHA";*/
            v8.Index = 8;
            v8.IconID = "$04040008";
            v8.IDS = "extreme";
            v8.Original = 0;
            v8.setCaption( "[Extreme] Type 4" );
            v8.setLength( 480 );
            v8.setStartDepth( 64 );
            v8.setDepthBP( new VibratoBPList( new float[] { 0.6042f, 0.6125f, 0.6167f, 0.6208f, 0.625f, 0.6333f, 0.6375f, 0.6417f, 0.6458f, 0.6542f, 0.6583f, 0.6667f, 0.6708f, 0.675f, 0.6792f, 0.6833f, 0.6917f, 0.6958f, 0.7042f, 0.7083f, 0.7125f, 0.7167f, 0.7208f, 0.725f, 0.7292f, 0.7375f, 0.7458f, 0.75f, 0.7583f, 0.7625f, 0.7667f, 0.7708f, 0.775f, 0.7833f, 0.7917f, 0.7958f, 0.8f, 0.8042f, 0.8083f, 0.8125f, 0.8208f, 0.8292f, 0.8375f, 0.8417f, 0.8458f, 0.85f, 0.8542f, 0.8625f, 0.8667f, 0.875f, 0.8792f, 0.8833f, 0.8875f, 0.8917f, 0.8958f, 0.9f, 1f }, new int[] { 64, 63, 62, 61, 59, 58, 57, 56, 55, 54, 52, 51, 50, 49, 48, 47, 45, 44, 43, 42, 41, 40, 39, 38, 37, 35, 34, 32, 31, 30, 29, 28, 27, 25, 24, 23, 22, 21, 20, 19, 17, 15, 14, 13, 12, 11, 10, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 } ) );
            v8.setStartRate( 64 );
            v8.setRateBP( new VibratoBPList( new float[] { 0.6042f, 0.6125f, 0.6167f, 0.6208f, 0.625f, 0.6333f, 0.6375f, 0.6417f, 0.6458f, 0.6542f, 0.6583f, 0.6667f, 0.6708f, 0.675f, 0.6792f, 0.6833f, 0.6917f, 0.6958f, 0.7042f, 0.7083f, 0.7125f, 0.7167f, 0.7208f, 0.725f, 0.7292f, 0.7375f, 0.7458f, 0.75f, 0.7583f, 0.7625f, 0.7667f, 0.7708f, 0.775f, 0.7833f, 0.7917f, 0.7958f, 0.8f, 0.8042f, 0.8083f, 0.8125f, 0.8208f, 0.8292f, 0.8375f, 0.8417f, 0.8458f, 0.85f, 0.8542f, 0.8625f, 0.8667f, 0.875f, 0.8792f, 0.8833f, 0.8875f, 0.8917f, 0.8958f, 0.9f, 1f }, new int[] { 64, 63, 62, 61, 59, 58, 57, 56, 55, 54, 52, 51, 50, 49, 48, 47, 45, 44, 43, 42, 41, 40, 39, 38, 37, 35, 34, 32, 31, 30, 29, 28, 27, 25, 24, 23, 22, 21, 20, 19, 17, 15, 14, 13, 12, 11, 10, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 } ) );
            ret.m_vibrato_configs.add( v8 );

            VibratoHandle v9 = new VibratoHandle();
            /*v9.author = "Standard";
            v9.file = "fast2_type1.aic";
            v9.number = 9;
            v9.vendor = "YAMAHA";*/
            v9.Index = 9;
            v9.IconID = "$04040009";
            v9.IDS = "fast";
            v9.Original = 0;
            v9.setCaption( "[Fast] Type 1" );
            v9.setLength( 480 );
            v9.setStartDepth( 64 );
            v9.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v9.setStartRate( 64 );
            v9.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v9 );

            VibratoHandle v10 = new VibratoHandle();
            /*v10.author = "Standard";
            v10.file = "fast2_type2.aic";
            v10.number = 10;
            v10.vendor = "YAMAHA";*/
            v10.Index = 10;
            v10.IconID = "$0404000a";
            v10.IDS = "fast";
            v10.Original = 0;
            v10.setCaption( "[Fast] Type 2" );
            v10.setLength( 480 );
            v10.setStartDepth( 40 );
            v10.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v10.setStartRate( 50 );
            v10.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v10 );

            VibratoHandle v11 = new VibratoHandle();
            /*v11.author = "Standard";
            v11.file = "fast2_type3.aic";
            v11.number = 11;
            v11.vendor = "YAMAHA";*/
            v11.Index = 11;
            v11.IconID = "$0404000b";
            v11.IDS = "fast";
            v11.Original = 0;
            v11.setCaption( "[Fast] Type 3" );
            v11.setLength( 480 );
            v11.setStartDepth( 80 );
            v11.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v11.setStartRate( 70 );
            v11.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v11 );

            VibratoHandle v12 = new VibratoHandle();
            /*v12.author = "Standard";
            v12.file = "fast2_type4.aic";
            v12.number = 12;
            v12.vendor = "YAMAHA";*/
            v12.Index = 12;
            v12.IconID = "$0404000c";
            v12.IDS = "fast";
            v12.Original = 0;
            v12.setCaption( "[Fast] Type 4" );
            v12.setLength( 480 );
            v12.setStartDepth( 64 );
            v12.setDepthBP( new VibratoBPList( new float[] { 0.6042f, 0.6125f, 0.6167f, 0.6208f, 0.625f, 0.6333f, 0.6375f, 0.6417f, 0.6458f, 0.6542f, 0.6583f, 0.6667f, 0.6708f, 0.675f, 0.6792f, 0.6833f, 0.6917f, 0.6958f, 0.7042f, 0.7083f, 0.7125f, 0.7167f, 0.7208f, 0.725f, 0.7292f, 0.7375f, 0.7458f, 0.75f, 0.7583f, 0.7625f, 0.7667f, 0.7708f, 0.775f, 0.7833f, 0.7917f, 0.7958f, 0.8f, 0.8042f, 0.8083f, 0.8125f, 0.8208f, 0.8292f, 0.8375f, 0.8417f, 0.8458f, 0.85f, 0.8542f, 0.8625f, 0.8667f, 0.875f, 0.8792f, 0.8833f, 0.8875f, 0.8917f, 0.8958f, 0.9f, 1f }, new int[] { 64, 63, 62, 61, 59, 58, 57, 56, 55, 54, 52, 51, 50, 49, 48, 47, 45, 44, 43, 42, 41, 40, 39, 38, 37, 35, 34, 32, 31, 30, 29, 28, 27, 25, 24, 23, 22, 21, 20, 19, 17, 15, 14, 13, 12, 11, 10, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 } ) );
            v12.setStartRate( 64 );
            v12.setRateBP( new VibratoBPList( new float[] { 0.6042f, 0.6125f, 0.6167f, 0.6208f, 0.625f, 0.6333f, 0.6375f, 0.6417f, 0.6458f, 0.6542f, 0.6583f, 0.6667f, 0.6708f, 0.675f, 0.6792f, 0.6833f, 0.6917f, 0.6958f, 0.7042f, 0.7083f, 0.7125f, 0.7167f, 0.7208f, 0.725f, 0.7292f, 0.7375f, 0.7458f, 0.75f, 0.7583f, 0.7625f, 0.7667f, 0.7708f, 0.775f, 0.7833f, 0.7917f, 0.7958f, 0.8f, 0.8042f, 0.8083f, 0.8125f, 0.8208f, 0.8292f, 0.8375f, 0.8417f, 0.8458f, 0.85f, 0.8542f, 0.8625f, 0.8667f, 0.875f, 0.8792f, 0.8833f, 0.8875f, 0.8917f, 0.8958f, 0.9f, 1f }, new int[] { 64, 63, 62, 61, 59, 58, 57, 56, 55, 54, 52, 51, 50, 49, 48, 47, 45, 44, 43, 42, 41, 40, 39, 38, 37, 35, 34, 32, 31, 30, 29, 28, 27, 25, 24, 23, 22, 21, 20, 19, 17, 15, 14, 13, 12, 11, 10, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 } ) );
            ret.m_vibrato_configs.add( v12 );

            VibratoHandle v13 = new VibratoHandle();
            /*v13.author = "Standard";
            v13.file = "slight2_type1.aic";
            v13.number = 13;
            v13.vendor = "YAMAHA";*/
            v13.Index = 13;
            v13.IconID = "$0404000d";
            v13.IDS = "slight";
            v13.Original = 0;
            v13.setCaption( "[Slight] Type 1" );
            v13.setLength( 480 );
            v13.setStartDepth( 64 );
            v13.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v13.setStartRate( 64 );
            v13.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v13 );

            VibratoHandle v14 = new VibratoHandle();
            /*v14.author = "Standard";
            v14.file = "slight2_type2.aic";
            v14.number = 14;
            v14.vendor = "YAMAHA";*/
            v14.Index = 14;
            v14.IconID = "$0404000e";
            v14.IDS = "slight";
            v14.Original = 0;
            v14.setCaption( "[Slight] Type 2" );
            v14.setLength( 480 );
            v14.setStartDepth( 40 );
            v14.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v14.setStartRate( 64 );
            v14.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v14 );

            VibratoHandle v15 = new VibratoHandle();
            /*v15.author = "Standard";
            v15.file = "slight2_type3.aic";
            v15.number = 15;
            v15.vendor = "YAMAHA";*/
            v15.Index = 15;
            v15.IconID = "$0404000f";
            v15.IDS = "slight";
            v15.Original = 0;
            v15.setCaption( "[Slight] Type 3" );
            v15.setLength( 480 );
            v15.setStartDepth( 72 );
            v15.setDepthBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            v15.setStartRate( 64 );
            v15.setRateBP( new VibratoBPList( new float[] { }, new int[] { } ) );
            ret.m_vibrato_configs.add( v15 );

            VibratoHandle v16 = new VibratoHandle();
            /*v16.author = "Standard";
            v16.file = "slight2_type4.aic";
            v16.number = 16;
            v16.vendor = "YAMAHA";*/
            v16.Index = 16;
            v16.IconID = "$04040010";
            v16.IDS = "slight";
            v16.Original = 0;
            v16.setCaption( "[Slight] Type 4" );
            v16.setLength( 480 );
            v16.setStartDepth( 64 );
            v16.setDepthBP( new VibratoBPList( new float[] { 0.6042f, 0.6125f, 0.6167f, 0.6208f, 0.625f, 0.6333f, 0.6375f, 0.6417f, 0.6458f, 0.6542f, 0.6583f, 0.6667f, 0.6708f, 0.675f, 0.6792f, 0.6833f, 0.6917f, 0.6958f, 0.7042f, 0.7083f, 0.7125f, 0.7167f, 0.7208f, 0.725f, 0.7292f, 0.7375f, 0.7458f, 0.75f, 0.7583f, 0.7625f, 0.7667f, 0.7708f, 0.775f, 0.7833f, 0.7917f, 0.7958f, 0.8f, 0.8042f, 0.8083f, 0.8125f, 0.8208f, 0.8292f, 0.8375f, 0.8417f, 0.8458f, 0.85f, 0.8542f, 0.8625f, 0.8667f, 0.875f, 0.8792f, 0.8833f, 0.8875f, 0.8917f, 0.8958f, 0.9f, 1f }, new int[] { 64, 63, 62, 61, 59, 58, 57, 56, 55, 54, 52, 51, 50, 49, 48, 47, 45, 44, 43, 42, 41, 40, 39, 38, 37, 35, 34, 32, 31, 30, 29, 28, 27, 25, 24, 23, 22, 21, 20, 19, 17, 15, 14, 13, 12, 11, 10, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 } ) );
            v16.setStartRate( 64 );
            v16.setRateBP( new VibratoBPList( new float[] { 0.6042f, 0.6125f, 0.6167f, 0.6208f, 0.625f, 0.6333f, 0.6375f, 0.6417f, 0.6458f, 0.6542f, 0.6583f, 0.6667f, 0.6708f, 0.675f, 0.6792f, 0.6833f, 0.6917f, 0.6958f, 0.7042f, 0.7083f, 0.7125f, 0.7167f, 0.7208f, 0.725f, 0.7292f, 0.7375f, 0.7458f, 0.75f, 0.7583f, 0.7625f, 0.7667f, 0.7708f, 0.775f, 0.7833f, 0.7917f, 0.7958f, 0.8f, 0.8042f, 0.8083f, 0.8125f, 0.8208f, 0.8292f, 0.8375f, 0.8417f, 0.8458f, 0.85f, 0.8542f, 0.8625f, 0.8667f, 0.875f, 0.8792f, 0.8833f, 0.8875f, 0.8917f, 0.8958f, 0.9f, 1f }, new int[] { 64, 63, 62, 61, 59, 58, 57, 56, 55, 54, 52, 51, 50, 49, 48, 47, 45, 44, 43, 42, 41, 40, 39, 38, 37, 35, 34, 32, 31, 30, 29, 28, 27, 25, 24, 23, 22, 21, 20, 19, 17, 15, 14, 13, 12, 11, 10, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0 } ) );
            ret.m_vibrato_configs.add( v16 );

            return ret;
        }

        public int getVibratoConfigCount() {
            return m_vibrato_configs.size();
        }

        public int getAttackConfigCount() {
            return m_attack_configs.size();
        }

        public Iterator vibratoConfigIterator() {
            return m_vibrato_configs.iterator();
        }

        public Iterator attackConfigIterator() {
            return m_attack_configs.iterator();
        }

        private ExpressionConfigSys() {
        }

        public ExpressionConfigSys( String path_expdb ) {
            m_vibrato_configs = new Vector<VibratoHandle>();
            m_attack_configs = new Vector<NoteHeadHandle>();
            String expression = PortUtil.combinePath( path_expdb, "expression.map" );
            if ( !PortUtil.isFileExists( expression ) ) {
#if DEBUG
                PortUtil.println( "ExpressionConfigSys#.ctor; expression.map does not exist" );
#endif
                return;
            }

            RandomAccessFile fs = null;
            try {
                fs = new RandomAccessFile( expression, "r" );
                byte[] dat = new byte[8];
                fs.seek( 0x20 );
                for ( int i = 0; i < MAX_VIBRATO; i++ ) {
                    fs.read( dat, 0, 8 );
                    long value = VocaloSysUtil.makelong_le( dat );
                    if ( value <= 0 ) {
                        continue;
                    }

                    String ved = PortUtil.combinePath( path_expdb, "vexp" + value + ".ved" );
                    if ( !PortUtil.isFileExists( ved ) ) {
                        continue;
                    }
                    String vexp_dir = PortUtil.combinePath( path_expdb, "vexp" + value );
                    if ( !PortUtil.isFileExists( vexp_dir ) ) {
                        continue;
                    }

#if DEBUG
                    PortUtil.println( "ExpresionConfigSys#.ctor; ved=" + ved + "; vexp_dir=" + vexp_dir );
#endif
                    String NL = (char)0x0D + "" + (char)0x0A;
                    RandomAccessFile fs_ved = null;
                    try {
                        fs_ved = new RandomAccessFile( ved, "r" );
                        byte[] byte_ved = new byte[(int)fs_ved.length()];
                        fs_ved.read( byte_ved, 0, byte_ved.Length );
                        TransCodeUtil.decodeBytes( byte_ved );
                        String str = PortUtil.getDecodedString( "ASCII", byte_ved );
#if DEBUG
                        String txt_file = PortUtil.combinePath( path_expdb, "vexp" + value + ".txt" );
                        using ( System.IO.StreamWriter sw = new System.IO.StreamWriter( txt_file ) ) {
                            sw.Write( str );
                        }
#endif
                        String[] spl = PortUtil.splitString( str, new String[] { NL }, true );
                        String current_entry = "";
                        for ( int j = 0; j < spl.Length; j++ ) {
#if DEBUG
                            //PortUtil.println( "ExpressionConfigSys#.ctor; line=" + spl[j] );
#endif
                            if ( spl[j].StartsWith( "[" ) ) {
                                current_entry = spl[j];
                                continue;
                            } else if ( spl[j].Equals( "" ) ) {
                                continue;
                            }
                            if ( current_entry.Equals( "[VIBRATO]" ) ) {
                                String[] spl2 = PortUtil.splitString( spl[j], ',' );
                                if ( spl2.Length < 6 ) {
                                    continue;
                                }
                                // ex: 1,1,"normal","normal2_type1.aic","[Normal]:Type:1","Standard","YAMAHA",0
                                String file = spl2[3].Replace( "\"", "" );
                                String aic_file = PortUtil.combinePath( vexp_dir, file );
                                int index = PortUtil.parseInt( spl2[0] );
                                String icon_id = "$0404" + PortUtil.toHexString( index, 4 );
                                String ids = spl2[2].Replace( "\"", "" );
                                VibratoHandle item = new VibratoHandle( aic_file, ids, icon_id, index );
                                m_vibrato_configs.add( item );
                            } if ( current_entry.Equals( "[NOTEATTACK]" ) ) {
                                String[] spl2 = PortUtil.splitString( spl[j], ',' );
                                if ( spl2.Length < 6 ) {
                                    continue;
                                }
                                // ex: 1,1,"normal","normal2_type1.aic","[Normal]:Type:1","Standard","YAMAHA",0
                                String file = spl2[3].Replace( "\"", "" );
                                String aic_path = PortUtil.combinePath( vexp_dir, file );
                                if ( !PortUtil.isFileExists( aic_path ) ) {
                                    continue;
                                }
                                String ids = spl2[2].Replace( "\"", "" );
                                int index = PortUtil.parseInt( spl2[0] );
                                String icon_id = "$0101" + PortUtil.toHexString( index, 4 );
                                NoteHeadHandle item = new NoteHeadHandle( aic_path, ids, icon_id, index );
                                m_attack_configs.add( item );
                            }
                        }
                    } catch ( Exception ex ) {
#if DEBUG
                        PortUtil.println( "ExpressionConfigSys#.ctor; ex=" + ex );
#endif
                    } finally {
                        if ( fs_ved != null ) {
                            try {
                                fs_ved.close();
                            } catch ( Exception ex2 ) {
#if DEBUG
                                PortUtil.println( "ExpressionConfigSys#.ctor; ex2=" + ex2 );
#endif
                            }
                        }
                    }
                }
            } catch ( Exception ex ) {
#if DEBUG
                PortUtil.println( "ExpressionConfigSys#.ctor; ex=" + ex );
#endif
            } finally {
                if ( fs != null ) {
                    try {
                        fs.close();
                    } catch ( Exception ex2 ) {
#if DEBUG
                        PortUtil.println( "ExpressionConfigSys#.ctor; ex2=" + ex2 );
#endif
                    }
                }
            }
        }

    }

#if !JAVA
}
#endif