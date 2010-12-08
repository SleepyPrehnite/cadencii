﻿/*
 * SelectedEventChangedEventHandler.cs
 * Copyright (C) 2009-2010 kbinani
 *
 * This file is part of org.kbinani.cadencii.
 *
 * org.kbinani.cadencii is free software; you can redistribute it and/or
 * modify it under the terms of the GPLv3 License.
 *
 * org.kbinani.cadencii is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 */
#if JAVA
//INCLUDE ../BuildJavaUI/src/org/kbinani/cadencii/SelectedEventChangedEventHandler.java
#else
using System;
using org.kbinani;

namespace org.kbinani.cadencii {

    public delegate void SelectedEventChangedEventHandler( object sender, bool foo );

}
#endif
