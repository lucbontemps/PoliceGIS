
Public Enum GeocodingStatusCode As Integer

    ''' <summary>
    ''' No match could be found in any way.
    ''' Not found should be the default value
    ''' </summary>
    ''' <remarks></remarks>
    NotFound = 0

    ''' <summary>
    ''' Variation of not found: there was an approximate match but the street was too long.
    ''' Approximate matches happen when there is an incomplete address and they take
    ''' the middle of the street segment as the location.  This means that long street
    ''' don't give very useful approximate matches.
    ''' </summary>
    ''' <remarks></remarks>
    LongStreet

    ''' <summary>
    ''' The match was made with the MapInfo geocoding, and an exact match was found
    ''' </summary>
    ''' <remarks></remarks>
    ExactMatchWithMapInfo

    ''' <summary>
    ''' The match was made with the MapInfo geocoding, and an approxiamte match was found.
    ''' (Address was incomplete)
    ''' </summary>
    ''' <remarks></remarks>
    ApproximateMatchWithMapInfo

    ''' <summary>
    ''' The match was made with a query on the address points. 
    ''' If a match is found with this method it is always an exact match.
    ''' </summary>
    ''' <remarks></remarks>
    ExactAddressPoint

    ''' <summary>
    ''' The match was made with a query on the hectometer poles. 
    ''' If a match is found with this method it is always an exact match.
    ''' </summary>
    ''' <remarks></remarks>
    ExactHectometerPole

End Enum