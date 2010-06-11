﻿/*
 * VsqBPList.js
 * Copyright (C) 2008-2010 kbinani
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
if( org == undefined ) var org = {};
if( org.kbinani == undefined ) org.kbinani = {};
if( org.kbinani.vsq == undefined ) org.kbinani.vsq = {};
if( org.kbinani.vsq.VsqBPList == undefined ){

    /// <summary>
    /// コントロールカーブのデータ点リスト
    /// </summary>
    org.kbinani.vsq.VsqBPList = function(){
        this.clocks = null;
        this.tems = null;
        this.length = 0; // clocks, itemsに入っているアイテムの個数
        this.defaultValue = 0;
        this.maxValue = 127;
        this.minValue = 0;
        this.maxId = 0;
        this.name = "";
    };

    org.kbinani.vsq.VsqBPList.INIT_BUFLEN = 512;

    org.kbinani.vsq.VsqBPList.KeyClockIterator = function(){
        this.m_list = null;
        this.m_pos = -1;
    };

    org.kbianni.vsq.VsqBPList.KeyClockIterator.prototype = {
        /**
         * @param list [VsqBPList]
         * @return [void]
         */
        init : function( list ) {
            this.m_list = list;
            this.m_pos = -1;
        },

        /**
         * @return [bool]
         */
        hasNext : function() {
            if ( this.m_pos + 1 < this.m_list.length ) {
                return true;
            } else {
                return false;
            }
        },

        /**
         * @return [int]
         */
        next : function() {
            this.m_pos++;
            return this.m_list.clocks[this.m_pos];
        },

        /**
         * @return [void]
         */
        remove : function() {
            if ( 0 <= this.m_pos && this.m_pos < this.m_list.length ) {
                var key = this.m_list.clocks[this.m_pos];
                for ( var i = this.m_pos; i < this.m_list.length - 1; i++ ) {
                    this.m_list.clocks[i] = this.m_list.clocks[i + 1];
                    this.m_list.items[i] = this.m_list.items[i + 1];
                }
                this.m_list.length = this.m_list.length - 1;
            }
        },
    };

    org.kbinani.vsq.VsqBPList.prototype = {
        /**
         * initializer
         * @return [void]
         */
        init : function(){
            if( arguments.length == 4 ){
                var name = arguments[0];
                var default_value = arguments[1];
                var minimum = arguments[2];
                var maximum = arguments[3];
                
                this.name = name;
                this.defaultValue = default_value;
                this.maxValue = maximum;
                this.minValue = minimum;
                this.maxId = 0;
            }
        },

        /**
         * @param length [int]
         * @return [void]
         */
        _ensureBufferLength : function( _length ) {
            if ( this.clocks == null ) {
                this.clocks = new Array( org.kbinani.vsq.VsqBPList.INIT_BUFLEN );
            }
            if ( this.items == null ) {
                this.items = new Array( org.kbinani.vsq.VsqBPList.INIT_BUFLEN );
            }
            if ( _length > this.clocks.length ) {
                var newLength = _length;
                if ( this.length <= 0 ) {
                    newLength = Math.floor( _length * 1.2 );
                } else {
                    var order = Math.floor( _length / this.clocks.Length );
                    if ( order <= 1 ) {
                        order = 2;
                    }
                    newLength = this.clocks.length * order;
                }
                var delta = newLength - this.clock.length;
                for( var i = 0; i < delta; i++ ){
                    this.clocks.push( 0 );
                    this.items.push( new org.kbinani.vsq.VsqBPPair() );
                }
            }
        },

        /**
         * @return [string]
         */
        getName : function() {
            if ( this.name == null ) {
                this.name = "";
            }
            return this.name;
        },

        /**
         * @param _value [string]
         * @return [void]
         */
        setName : function( _value ) {
            if ( value == null ) {
                this.name = "";
            } else {
                this.name = _value;
            }
        },

        /**
         * @return [long]
         */
        getMaxID : function() {
            return this.maxId;
        },

        /**
         * このBPListのデフォルト値を取得します
         * @return [int]
         */
        getDefault : function() {
            return this.defaultValue;
        },

        /**
         * @param _value [int]
         * @return [void]
         */
        setDefault : function( _value ) {
            this.defaultValue = _value;
        },

        /**
         * データ点のIDを一度クリアし，新たに番号付けを行います．
         * IDは，Redo,Undo用コマンドが使用するため，このメソッドを呼ぶとRedo,Undo操作が破綻する．XMLからのデシリアライズ直後のみ使用するべき．
         *
         * @return [void]
         */
        renumberIDs : function() {
            this.maxId = 0;
            for ( var i = 0; i < this.length; i++ ) {
                this.maxId++;
                var v = items[i];
                v.id = this.maxId;
                this.items[i] = v;
            }
        },

        /**
         * @return [string]
         */
        getData : function() {
            var ret = "";
            for ( var i = 0; i < this.length; i++ ) {
                ret += (i == 0 ? "" : ",") + this.clocks[i] + "=" + this.items[i].value;
            }
            return ret;
        },

        /**
         * @param value [string]
         * @return [void]
         */
        setData : function( value ) {
            this.length = 0;
            this.maxId = 0;
            var spl = value.split( ',' );
            for ( var i = 0; i < spl.length; i++ ) {
                var spl2 = spl[i].split( '=' );
                if ( spl2.length < 2 ) {
                    continue;
                }
                var clock = parseInt( spl2[0], 10 );
                if( !isNaN( clock ) ){
                    _ensureBufferLength( this.length + 1 );
                    this.clocks[length] = clock;
                    this.items[length] = new org.kbinani.vsq.VsqBPPair( parseInt( spl2[1], 10 ), this.maxId + 1 );
                    this.maxId++;
                    this.length++;
                }
            }
        },

        /**
         * このVsqBPListの同一コピーを作成します
         *
         * @return [object]
         */
        clone : function() {
            var res = new org.kbinani.vsq.VsqBPList( this.name, this.defaultValue, this.minValue, this.maxValue );
            res._ensureBufferLength( this.length );
            for ( var i = 0; i < this.length; i++ ) {
                res.clocks[i] = this.clocks[i];
                res.items[i] = this.items[i].clone();
            }
            res.length = this.length;
            res.maxId = this.maxId;
            return res;
        },

        /**
         * このリストに設定された最大値を取得します。
         * @return [int]
         */
        getMaximum : function() {
            return this.maxValue;
        },

        /**
         * @param value[ int]
         * @return [void]
         */
        setMaximum : function( value ) {
            this.maxValue = value;
        },

        /**
         * このリストに設定された最小値を取得します
         *
         * @return [int]
         */
        getMinimum : function() {
            return this.minValue;
        },

        /**
         * @param vlaue [int]
         * @return [void]
         */
        setMinimum : function( value ) {
            this.minValue = value;
        },

        /**
         * @param clock [int]
         * @return [void]
         */
        remove : function( clock ) {
            _ensureBufferLength( this.length );
            var index = find( clock );
            removeElementAt( index );
        },

        /**
         * @param index [int]
         * @return [void]
         */
        removeElementAt : function( index ) {
            if ( index >= 0 ) {
                for ( var i = index; i < this.length - 1; i++ ) {
                    this.clocks[i] = this.clocks[i + 1];
                    this.items[i] = this.items[i + 1];
                }
                this.length--;
            }
        },

        /**
         * @param clock [int]
         * @return [bool]
         */
        isContainsKey : function( clock ) {
            _ensureBufferLength( this.length );
            return (find( clock ) >= 0);
        },

        /**
         * 時刻clockのデータを時刻new_clockに移動します。
         * 時刻clockにデータがなければ何もしない。
         * 時刻new_clockに既にデータがある場合、既存のデータは削除される。
         *
         * @param clock [int]
         * @param new_clock [int]
         * @param new_value [int]
         * @return [void]
         */
        move : function( clock, new_clock, new_value ) {
            _ensureBufferLength( this.length );
            var index = find( clock );
            if ( index < 0 ) {
                return;
            }
            var item = this.items[index];
            for ( var i = index; i < this.length - 1; i++ ) {
                this.clocks[i] = this.clocks[i + 1];
                this.items[i] = this.items[i + 1];
            }
            this.length--;
            var index_new = find( new_clock );
            if ( index_new >= 0 ) {
                item.value = new_value;
                this.items[index_new] = item;
                return;
            } else {
                this.length++;
                _ensureBufferLength( this.length );
                this.clocks[this.length - 1] = new_clock;
                org.kbinani.PortUtil.sort( clocks, 0, length );
                index_new = find( new_clock );
                item.value = new_value;
                for ( var i = this.length - 1; i > index_new; i-- ) {
                    this.items[i] = this.items[i - 1];
                }
                this.items[index_new] = item;
            }
        },

        /**
         * @return [void]
         */
        clear : function() {
            length = 0;
        },

        /**
         * @param index [int]
         * @return [int]
         */
        getElement : function( index ) {
            return getElementA( index );
        },

        /**
         * @param index [int]
         * @return [int]
         */
        getElementA : function( index ) {
            return this.items[index].value;
        },

        /**
         * @param index [int]
         * @return [VsqBPPair]
         */
        getElementB : function( index ) {
            return this.items[index];
        },

        /**
         * @param index [int]
         * @return [int]
         */
        getKeyClock : function( index ) {
            return this.clocks[index];
        },

        /**
         * @param id [long]
         * @return [int]
         */
        findValueFromID : function( id ) {
            for ( var i = 0; i < this.length; i++ ) {
                var item = this.items[i];
                if ( item.id == id ) {
                    return item.value;
                }
            }
            return this.defaultValue;
        },

        /**
         * 指定したid値を持つVsqBPPairを検索し、その結果を返します。
         *
         * @param id [long]
         * @return [VsqBPPairSearchContext]
         */
        findElement : function( id ) {
            var context = new org.kbinani.vsq.VsqBPPairSearchContext();
            for ( var i = 0; i < this.length; i++ ) {
                var item = this.items[i];
                if ( item.id == id ) {
                    context.clock = clocks[i];
                    context.index = i;
                    context.point = item;
                    return context;
                }
            }
            context.clock = -1;
            context.index = -1;
            context.point = new org.kbinani.vsq.VsqBPPair( this.defaultValue, -1 );
            return context;
        },

        /**
         * @param id [long]
         * @param value [int]
         * @return [void]
         */
        setValueForID : function( id, value ) {
            for ( var i = 0; i < length; i++ ) {
                var item = this.items[i];
                if ( item.id == id ) {
                    item.value = value;
                    items[i] = item;
                    break;
                }
            }
        },

        /**
         * @param clock [int]
         * @param index [ByRef<int>]
         * @return [int]
         */
        getValue : function( clock, index ) {
            if ( this.length == 0 ) {
                return this.defaultValue;
            } else {
                if ( index.value < 0 ) {
                    index.value = 0;
                }
                for ( var i = index.value; i < this.length; i++ ) {
                    var keyclock = this.clocks[i];
                    if ( clock < keyclock ) {
                        if ( i > 0 ) {
                            index.value = i - 1;
                            return this.items[i - 1].value;
                        } else {
                            index.value = i - 1;
                            return this.defaultValue;
                        }
                    }
                }
                index.value = this.length - 1;
                return this.items[this.length - 1].value;
            }
        },

        /*
        //TODO: VsqBPList#print and related functions
        private void printCor( ITextWriter writer, int start_clock, String header )
#if JAVA
            throws IOException
#endif
        {
            writer.writeLine( header );
            int lastvalue = defaultValue;
            boolean value_at_start_written = false;
            for ( int i = 0; i < length; i++ ) {
                int key = clocks[i];
                if ( start_clock == key ) {
                    writer.writeLine( key + "=" + items[i].value );
                    value_at_start_written = true;
                } else if ( start_clock < key ) {
                    if ( !value_at_start_written && lastvalue != defaultValue ) {
                        writer.writeLine( start_clock + "=" + lastvalue );
                        value_at_start_written = true;
                    }
                    int val = items[i].value;
                    writer.writeLine( key + "=" + val );
                } else {
                    lastvalue = items[i].value;
                }
            }
            if ( !value_at_start_written && lastvalue != defaultValue ) {
                writer.writeLine( start_clock + "=" + lastvalue );
            }
        }

        /// <summary>
        /// このBPListの内容をテキストファイルに書き出します
        /// </summary>
        /// <param name="writer"></param>
        public void print( BufferedWriter writer, int start, String header )
#if JAVA
            throws IOException
#endif
 {
            printCor( new WrappedStreamWriter( writer ), start, header );
        }

        /// <summary>
        /// このBPListの内容をテキストファイルに書き出します
        /// </summary>
        /// <param name="writer"></param>
        public void print( ITextWriter writer, int start, String header )
#if JAVA
            throws IOException
#endif
 {
            printCor( writer, start, header );
        }*/

        /// <summary>
        /// テキストファイルからデータ点を読込み、現在のリストに追加します
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public String appendFromText( TextStream reader ) {
#if DEBUG
            PortUtil.println( "VsqBPList#appendFromText; start" );
            double started = PortUtil.getCurrentTime();
            int count = 0;
#endif
            int clock = 0;
            int value = 0;
            int minus = 1;
            int mode = 0; // 0: clockを読んでいる, 1: valueを読んでいる
            while ( reader.ready() ) {
                char ch = reader.get();
                if ( ch == '\n' ) {
                    if ( mode == 1 ) {
                        addWithoutSort( clock, value * minus );
                        mode = 0;
                        clock = 0;
                        value = 0;
                        minus = 1;
                    }
                    continue;
                }
                if ( ch == '[' ) {
                    if ( mode == 1 ) {
                        addWithoutSort( clock, value * minus );
                        mode = 0;
                        clock = 0;
                        value = 0;
                        minus = 1;
                    }
                    reader.setPointer( reader.getPointer() - 1 );
                    break;
                }
                if ( ch == '=' ) {
                    mode = 1;
                    continue;
                }
                if ( ch == '-' ) {
                    minus = -1;
                    continue;
                }
#if JAVA
                if( Character.isDigit( ch ) ){
#else
                if ( Char.IsNumber( ch ) ) {
#endif
                    int num = 0;
                    if ( ch == '1' ) {
                        num = 1;
                    } else if ( ch == '2' ) {
                        num = 2;
                    } else if ( ch == '3' ) {
                        num = 3;
                    } else if ( ch == '4' ) {
                        num = 4;
                    } else if ( ch == '5' ) {
                        num = 5;
                    } else if ( ch == '6' ) {
                        num = 6;
                    } else if ( ch == '7' ) {
                        num = 7;
                    } else if ( ch == '8' ) {
                        num = 8;
                    } else if ( ch == '9' ) {
                        num = 9;
                    }
                    if ( mode == 0 ) {
                        clock = clock * 10 + num;
                    } else {
                        value = value * 10 + num;
                    }
                }
            }
            return reader.readLine();
        }

        public int size() {
            return length;
        }

        public Iterator<Integer> keyClockIterator() {
            return new KeyClockIterator( this );
        }

        private int find( int value ) {
#if JAVA
            // caution: length of array 'clocks' is equal to or larger than the value of 'length' field.
            // 配列clocksの長さは、フィールドlengthの値と等しいか、大きい。
#if JAVA_1_5
            for( int i = 0; i < length; i++ ){
                if( clocks[i] == value ){
                    return i;
                }
            }
            return -1;
#else
            return Arrays.binarySearch( clocks, 0, length, value );
#endif
#else
            return Array.BinarySearch( clocks, 0, length, value );
#endif
            //return Array.IndexOf( clocks, value, 0, length );
        }

        /// <summary>
        /// 並べ替え，既存の値との重複チェックを行わず，リストの末尾にデータ点を追加する
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private void addWithoutSort( int clock, int value ) {
            ensureBufferLength( length + 1 );
            clocks[length] = clock;
            maxId++;
#if JAVA
            items[length] = new VsqBPPair( value, maxId );
#else
            items[length].value = value;
            items[length].id = maxId;
#endif
            length++;
        }

        public long add( int clock, int value ) {
            ensureBufferLength( length );
            int index = find( clock );
            if ( index >= 0 ) {
                VsqBPPair v = items[index];
                v.value = value;
                items[index] = v;
                return v.id;
            } else {
                length++;
                ensureBufferLength( length );
                clocks[length - 1] = clock;
#if JAVA
                Arrays.sort( clocks, 0, length );
#else
                Array.Sort( clocks, 0, length );
#endif
                index = find( clock );
                maxId++;
                for ( int i = length - 1; i > index; i-- ) {
                    items[i] = items[i - 1];
                }
                items[index] = new VsqBPPair( value, maxId );
                return maxId;
            }
        }

        public void addWithID( int clock, int value, long id ) {
            ensureBufferLength( length );
            int index = find( clock );
            if ( index >= 0 ) {
                VsqBPPair v = items[index];
                v.value = value;
                v.id = id;
                items[index] = v;
            } else {
                length++;
                ensureBufferLength( length );
                clocks[length - 1] = clock;
#if JAVA
                Arrays.sort( clocks, 0, length );
#else
                Array.Sort( clocks, 0, length );
#endif
                index = find( clock );
                for ( int i = length - 1; i > index; i-- ) {
                    items[i] = items[i - 1];
                }
                items[index] = new VsqBPPair( value, id );
                maxId = Math.Max( maxId, id );
            }
        }

        public void removeWithID( long id ) {
            for ( int i = 0; i < length; i++ ) {
                if ( items[i].id == id ) {
                    for ( int j = i; j < length - 1; j++ ) {
                        items[j] = items[j + 1];
                        clocks[j] = clocks[j + 1];
                    }
                    length--;
                    break;
                }
            }
        }

        public int getValue( int clock ) {
            ensureBufferLength( length );
            int index = find( clock );
            if ( index >= 0 ) {
                return items[index].value;
            } else {
                if ( length <= 0 ) {
                    return defaultValue;
                } else {
                    int draft = -1;
                    for ( int i = 0; i < length; i++ ) {
                        int c = clocks[i];
                        if ( clock < c ) {
                            break;
                        }
                        draft = i;
                    }
                    if ( draft < 0 ) {
                        return defaultValue;
                    } else {
                        return items[draft].value;
                    }
                }
            }
        }
    }

#if !JAVA
}
#endif

