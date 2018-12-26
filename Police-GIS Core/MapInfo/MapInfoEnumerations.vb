Option Strict On

Public Enum MIColumnType As Short

    CharType = MapBasicConstants.COL_TYPE_CHAR
    DecimalType = MapBasicConstants.COL_TYPE_DECIMAL
    IntegerType = MapBasicConstants.COL_TYPE_INTEGER
    SmallintType = MapBasicConstants.COL_TYPE_SMALLINT
    DateType = MapBasicConstants.COL_TYPE_DATE
    LogicalType = MapBasicConstants.COL_TYPE_LOGICAL
    GraphicType = MapBasicConstants.COL_TYPE_GRAPHIC
    FloatType = MapBasicConstants.COL_TYPE_FLOAT
    TimeType = MapBasicConstants.COL_TYPE_TIME
    DatetimeType = MapBasicConstants.COL_TYPE_DATETIME

End Enum


Public Enum MITableType As Short

    Base = MapBasicConstants.TAB_TYPE_BASE
    Fme = MapBasicConstants.TAB_TYPE_FME
    Image = MapBasicConstants.TAB_TYPE_IMAGE
    Linked = MapBasicConstants.TAB_TYPE_LINKED
    Result = MapBasicConstants.TAB_TYPE_RESULT
    View = MapBasicConstants.TAB_TYPE_VIEW
    Wfs = MapBasicConstants.TAB_TYPE_WFS
    Wms = MapBasicConstants.TAB_TYPE_WMS

End Enum

Public Enum MITableInfo As Short

    NAME = MapBasicConstants.TAB_INFO_NAME
    NUM = MapBasicConstants.TAB_INFO_NUM
    TYPE = MapBasicConstants.TAB_INFO_TYPE
    NCOLS = MapBasicConstants.TAB_INFO_NCOLS
    MAPPABLE = MapBasicConstants.TAB_INFO_MAPPABLE
    IsREADONLY = MapBasicConstants.TAB_INFO_READONLY
    TEMP = MapBasicConstants.TAB_INFO_TEMP
    NROWS = MapBasicConstants.TAB_INFO_NROWS
    EDITED = MapBasicConstants.TAB_INFO_EDITED
    FASTEDIT = MapBasicConstants.TAB_INFO_FASTEDIT
    UNDO = MapBasicConstants.TAB_INFO_UNDO
    MAPPABLE_TABLE = MapBasicConstants.TAB_INFO_MAPPABLE_TABLE
    USERMAP = MapBasicConstants.TAB_INFO_USERMAP
    USERBROWSE = MapBasicConstants.TAB_INFO_USERBROWSE
    USERCLOSE = MapBasicConstants.TAB_INFO_USERCLOSE
    USEREDITABLE = MapBasicConstants.TAB_INFO_USEREDITABLE
    USERREMOVEMAP = MapBasicConstants.TAB_INFO_USERREMOVEMAP
    USERDISPLAYMAP = MapBasicConstants.TAB_INFO_USERDISPLAYMAP
    TABFILE = MapBasicConstants.TAB_INFO_TABFILE
    MINX = MapBasicConstants.TAB_INFO_MINX
    MINY = MapBasicConstants.TAB_INFO_MINY
    MAXX = MapBasicConstants.TAB_INFO_MAXX
    MAXY = MapBasicConstants.TAB_INFO_MAXY
    SEAMLESS = MapBasicConstants.TAB_INFO_SEAMLESS
    COORDSYS_MINX = MapBasicConstants.TAB_INFO_COORDSYS_MINX
    COORDSYS_MINY = MapBasicConstants.TAB_INFO_COORDSYS_MINY
    COORDSYS_MAXX = MapBasicConstants.TAB_INFO_COORDSYS_MAXX
    COORDSYS_MAXY = MapBasicConstants.TAB_INFO_COORDSYS_MAXY
    COORDSYS_CLAUSE = MapBasicConstants.TAB_INFO_COORDSYS_CLAUSE
    COORDSYS_NAME = MapBasicConstants.TAB_INFO_COORDSYS_NAME
    NREFS = MapBasicConstants.TAB_INFO_NREFS
    SUPPORT_MZ = MapBasicConstants.TAB_INFO_SUPPORT_MZ
    Z_UNIT_SET = MapBasicConstants.TAB_INFO_Z_UNIT_SET
    Z_UNIT = MapBasicConstants.TAB_INFO_Z_UNIT
    BROWSER_LIST = MapBasicConstants.TAB_INFO_BROWSER_LIST
    THEME_METADATA = MapBasicConstants.TAB_INFO_THEME_METADATA
    COORDSYS_CLAUSE_WITHOUT_BOUNDS = MapBasicConstants.TAB_INFO_COORDSYS_CLAUSE_WITHOUT_BOUNDS

End Enum
