// ==++==
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--==

namespace System.Collections.Generic
{
    using System;

    // The generic IEqualityComparer interface implements methods to if check two objects are equal
    // and generate Hashcode for an object.
    // It is use in Dictionary class.
    public interface IEqualityComparer<T>
    {
        bool Equals( T x, T y );

        int GetHashCode( T obj );
    }
}

