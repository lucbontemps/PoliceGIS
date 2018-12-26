
Option Strict On

Public Class MapBasicConstants

    '============================================================================
    ' MapInfo version 10.0 - System defines
    '----------------------------------------------------------------------------
    ' This file contains defines useful when programming in the MapBasic
    ' language.  There are three versions of this file:
    '     MAPBASIC.DEF  - MapBasic syntax
    '     MAPBASIC.BAS  - Visual Basic syntax
    '     MAPBASIC.H    - C/C++ syntax
    '----------------------------------------------------------------------------
    ' The defines in this file are organized into the following sections:
    '     General Purpose defines:
    '       macros, logical constants, angle conversion, colors, string length
    '     ButtonPadInfo() defines
    '     ColumnInfo() and column type defines
    '     CommandInfo() and task switch defines
    '     DateWindow() defines
    '     FileAttr() and file access mode defines
    '     GetFolderPath$() defines
    '     IntersectNodes() parameters
    '     LabelInfo() defines
    '     GroupLayerInfo() defines
    '     LayerListInfo() defines
    '     LayerInfo(), display mode, label property, layer type, hotlink defines
    '     LegendInfo() and legend orientation defines
    '     LegendFrameInfo() and frame type defines
    '     LegendStyleInfo() defines
    '     LocateFile$() defines
    '     Map3DInfo() defines
    '     MapperInfo(), display mode, calculation type, and clip type defines
    '     MenuItemInfoByID() and MenuItemInfoByHandler() defines
    '     ObjectGeography() defines
    '     ObjectInfo() and object type defines
    '     PrismMapInfo() defines
    '     SearchInfo() defines
    '     SelectionInfo() defines
    '     Server statement and function defines
    '     SessionInfo() defines
    '     Set Next Document Style defines
    '     StringCompare() return values
    '     StyleAttr() defines
    '     SystemInfo(), platform, and version defines
    '     TableInfo() and table type defines
    '     WindowInfo(), window type and state, and print orientation defines
    '     Abbreviated list of error codes
    '     Backward Compatibility defines
    '============================================================================
    ' MAPBASIC.DEF is converted into MAPBASIC.H by doing the following:
    '   - concatenate MAPBASIC.DEF and MENU.DEF into MAPBASIC.H
    '   - search & replace "'" at begining of a line with "//"
    '   - search & replace "Define" at begining of a line with "#define"
    '   - delete the following sections:
    '         * General Purpose defines:
    '              Macros, Logical Constants, Angle Conversions
    '         * Abbreviated list of error codes
    '         * Backward Compatibility defines
    '         * Menu constants whose names have changed
    '         * Obsolete menu items
    '============================================================================
    ' MAPBASIC.DEF is converted into MAPBASIC.BAS by doing the following:
    '   - concatenate MAPBASIC.DEF and MENU.DEF into MAPBASIC.BAS
    '   - search & replace "Define <name>" with "Public Const <name> ="
    '     e.g. "<Define {[!-z]+} +{[!-z]}" with "Public Const \0 = \1" with Brief
    '   - delete the following sections:
    '         * General Purpose defines:
    '             Macros, Logical Constants, Angle Conversions
    '         * Abbreviated list of error codes
    '         * Backward Compatibility defines
    '         * Menu constants whose names have changed
    '         * Obsolete menu items
    '============================================================================

    '============================================================================
    ' General Purpose defines
    '============================================================================
    '----------------------------------------------------------------------------
    ' Colors
    '----------------------------------------------------------------------------
    Public Const BLACK As Integer = 0
    Public Const WHITE As Integer = 16777215
    Public Const RED As Integer = 16711680
    Public Const GREEN As Integer = 65280
    Public Const BLUE As Integer = 255
    Public Const CYAN As Integer = 65535
    Public Const MAGENTA As Integer = 16711935
    Public Const YELLOW As Integer = 16776960

    '----------------------------------------------------------------------------
    'Maximum length for character string
    '----------------------------------------------------------------------------
    Public Const MAX_STRING_LENGTH As Short = 32767

    '============================================================================
    ' ButtonPadInfo() defines
    '============================================================================
    Public Const BTNPAD_INFO_FLOATING As Short = 1
    Public Const BTNPAD_INFO_WIDTH As Short = 2
    Public Const BTNPAD_INFO_NBTNS As Short = 3
    Public Const BTNPAD_INFO_X As Short = 4
    Public Const BTNPAD_INFO_Y As Short = 5
    Public Const BTNPAD_INFO_WINID As Short = 6

    '============================================================================
    ' ColumnInfo() defines
    '============================================================================
    Public Const COL_INFO_NAME As Short = 1
    Public Const COL_INFO_NUM As Short = 2
    Public Const COL_INFO_TYPE As Short = 3
    Public Const COL_INFO_WIDTH As Short = 4
    Public Const COL_INFO_DECPLACES As Short = 5
    Public Const COL_INFO_INDEXED As Short = 6
    Public Const COL_INFO_EDITABLE As Short = 7

    '----------------------------------------------------------------------------
    ' Column type defines, returned by ColumnInfo() for COL_INFO_TYPE
    '----------------------------------------------------------------------------
    Public Const COL_TYPE_CHAR As Short = 1
    Public Const COL_TYPE_DECIMAL As Short = 2
    Public Const COL_TYPE_INTEGER As Short = 3
    Public Const COL_TYPE_SMALLINT As Short = 4
    Public Const COL_TYPE_DATE As Short = 5
    Public Const COL_TYPE_LOGICAL As Short = 6
    Public Const COL_TYPE_GRAPHIC As Short = 7
    Public Const COL_TYPE_FLOAT As Short = 8
    Public Const COL_TYPE_TIME As Short = 37
    Public Const COL_TYPE_DATETIME As Short = 38

    '============================================================================
    ' CommandInfo() defines
    '============================================================================
    Public Const CMD_INFO_X As Short = 1
    Public Const CMD_INFO_Y As Short = 2
    Public Const CMD_INFO_SHIFT As Short = 3
    Public Const CMD_INFO_CTRL As Short = 4
    Public Const CMD_INFO_X2 As Short = 5
    Public Const CMD_INFO_Y2 As Short = 6
    Public Const CMD_INFO_TOOLBTN As Short = 7
    Public Const CMD_INFO_MENUITEM As Short = 8
    Public Const CMD_INFO_WIN As Short = 1
    Public Const CMD_INFO_SELTYPE As Short = 1
    Public Const CMD_INFO_ROWID As Short = 2
    Public Const CMD_INFO_INTERRUPT As Short = 3
    Public Const CMD_INFO_STATUS As Short = 1
    Public Const CMD_INFO_MSG As Short = 1000
    Public Const CMD_INFO_DLG_OK As Short = 1
    Public Const CMD_INFO_DLG_DBL As Short = 1
    Public Const CMD_INFO_FIND_RC As Short = 3
    Public Const CMD_INFO_FIND_ROWID As Short = 4
    Public Const CMD_INFO_XCMD As Short = 1
    Public Const CMD_INFO_CUSTOM_OBJ As Short = 1
    Public Const CMD_INFO_TASK_SWITCH As Short = 1
    Public Const CMD_INFO_EDIT_TABLE As Short = 1
    Public Const CMD_INFO_EDIT_STATUS As Short = 2
    Public Const CMD_INFO_EDIT_ASK As Short = 1
    Public Const CMD_INFO_EDIT_SAVE As Short = 2
    Public Const CMD_INFO_EDIT_DISCARD As Short = 3
    Public Const CMD_INFO_HL_WINDOW_ID As Short = 17
    Public Const CMD_INFO_HL_TABLE_NAME As Short = 18
    Public Const CMD_INFO_HL_ROWID As Short = 19
    Public Const CMD_INFO_HL_LAYER_ID As Short = 20
    Public Const CMD_INFO_HL_FILE_NAME As Short = 21

    '----------------------------------------------------------------------------
    ' Task Switches, returned by CommandInfo() for CMD_INFO_TASK_SWITCH
    '----------------------------------------------------------------------------
    Public Const SWITCHING_OUT_OF_MAPINFO As Short = 0
    Public Const SWITCHING_INTO_MAPINFO As Short = 1

    '============================================================================
    ' DateWindow() defines
    '============================================================================
    Public Const DATE_WIN_SESSION As Short = 1
    Public Const DATE_WIN_CURPROG As Short = 2

    '============================================================================
    ' FileAttr() defines
    '============================================================================
    Public Const FILE_ATTR_MODE As Short = 1
    Public Const FILE_ATTR_FILESIZE As Short = 2

    '----------------------------------------------------------------------------
    ' File Access Modes, returned by FileAttr() for FILE_ATTR_MODE
    '----------------------------------------------------------------------------
    Public Const MODE_INPUT As Short = 0
    Public Const MODE_OUTPUT As Short = 1
    Public Const MODE_APPEND As Short = 2
    Public Const MODE_RANDOM As Short = 3
    Public Const MODE_BINARY As Short = 4

    '============================================================================
    ' GetFolderPath$() defines
    '============================================================================

    Public Const FOLDER_MI_APPDATA As Short = -1
    Public Const FOLDER_MI_LOCAL_APPDATA As Short = -2
    Public Const FOLDER_MI_PREFERENCE As Short = -3
    Public Const FOLDER_MI_COMMON_APPDATA As Short = -4
    Public Const FOLDER_APPDATA As Short = 26
    Public Const FOLDER_LOCAL_APPDATA As Short = 28
    Public Const FOLDER_COMMON_APPDATA As Short = 35
    Public Const FOLDER_COMMON_DOCS As Short = 46
    Public Const FOLDER_MYDOCS As Short = 5
    Public Const FOLDER_MYPICS As Short = 39

    '============================================================================
    ' IntersectNodes() defines
    '============================================================================
    Public Const INCL_CROSSINGS As Short = 1
    Public Const INCL_COMMON As Short = 6
    Public Const INCL_ALL As Short = 7

    '============================================================================
    ' LabelInfo() defines
    '============================================================================
    Public Const LABEL_INFO_OBJECT As Short = 1
    Public Const LABEL_INFO_POSITION As Short = 2
    Public Const LABEL_INFO_ANCHORX As Short = 3
    Public Const LABEL_INFO_ANCHORY As Short = 4
    Public Const LABEL_INFO_OFFSET As Short = 5
    Public Const LABEL_INFO_ROWID As Short = 6
    Public Const LABEL_INFO_TABLE As Short = 7
    Public Const LABEL_INFO_EDIT As Short = 8
    Public Const LABEL_INFO_EDIT_VISIBILITY As Short = 9
    Public Const LABEL_INFO_EDIT_ANCHOR As Short = 10
    Public Const LABEL_INFO_EDIT_OFFSET As Short = 11
    Public Const LABEL_INFO_EDIT_FONT As Short = 12
    Public Const LABEL_INFO_EDIT_PEN As Short = 13
    Public Const LABEL_INFO_EDIT_TEXT As Short = 14
    Public Const LABEL_INFO_EDIT_TEXTARROW As Short = 15
    Public Const LABEL_INFO_EDIT_ANGLE As Short = 16
    Public Const LABEL_INFO_EDIT_POSITION As Short = 17
    Public Const LABEL_INFO_EDIT_TEXTLINE As Short = 18
    Public Const LABEL_INFO_SELECT As Short = 19
    Public Const LABEL_INFO_DRAWN As Short = 20
    Public Const LABEL_INFO_ORIENTATION As Short = 21

    '============================================================================
    ' Codes passed to the GroupLayerInfo function to get info about a group layer.
    '============================================================================
    Public Const GROUPLAYER_INFO_NAME As Short = 1
    Public Const GROUPLAYER_INFO_LAYERLIST_ID As Short = 2
    Public Const GROUPLAYER_INFO_DISPLAY As Short = 3
    Public Const GROUPLAYER_INFO_LAYERS As Short = 4
    Public Const GROUPLAYER_INFO_ALL_LAYERS As Short = 5
    Public Const GROUPLAYER_INFO_TOPLEVEL_LAYERS As Short = 6
    Public Const GROUPLAYER_INFO_PARENT_GROUP_ID As Short = 7

    '============================================================================
    ' Values returned by GroupLayerInfo() for GROUPLAYER_INFO_DISPLAY. These
    ' defines correspond to the MapBasic defines in MAPBASIC.DEF. If you alter
    ' these you must alter MAPBASIC.DEF.
    '============================================================================
    Public Const GROUPLAYER_INFO_DISPLAY_OFF As Short = 0
    Public Const GROUPLAYER_INFO_DISPLAY_ON As Short = 1

    '============================================================================
    ' Codes passed to the LayerListInfo function to help enumerating all layers in a Map.
    '============================================================================
    Public Const LAYERLIST_INFO_TYPE As Short = 1
    Public Const LAYERLIST_INFO_NAME As Short = 2
    Public Const LAYERLIST_INFO_LAYER_ID As Short = 3
    Public Const LAYERLIST_INFO_GROUPLAYER_ID As Short = 4

    '============================================================================
    ' Values returned by LayerListInfo() for LAYERLIST_INFO_TYPE. These		*/
    ' defines correspond to the MapBasic defines in MAPBASIC.DEF. If you alter */
    ' these you must alter MAPBASIC.DEF.                                       */
    '============================================================================
    Public Const LAYERLIST_INFO_TYPE_LAYER As Short = 0
    Public Const LAYERLIST_INFO_TYPE_GROUP As Short = 1

    '============================================================================
    ' LayerInfo() defines
    '============================================================================
    Public Const LAYER_INFO_NAME As Short = 1
    Public Const LAYER_INFO_EDITABLE As Short = 2
    Public Const LAYER_INFO_SELECTABLE As Short = 3
    Public Const LAYER_INFO_ZOOM_LAYERED As Short = 4
    Public Const LAYER_INFO_ZOOM_MIN As Short = 5
    Public Const LAYER_INFO_ZOOM_MAX As Short = 6
    Public Const LAYER_INFO_COSMETIC As Short = 7
    Public Const LAYER_INFO_PATH As Short = 8
    Public Const LAYER_INFO_DISPLAY As Short = 9
    Public Const LAYER_INFO_OVR_LINE As Short = 10
    Public Const LAYER_INFO_OVR_PEN As Short = 11
    Public Const LAYER_INFO_OVR_BRUSH As Short = 12
    Public Const LAYER_INFO_OVR_SYMBOL As Short = 13
    Public Const LAYER_INFO_OVR_FONT As Short = 14
    Public Const LAYER_INFO_LBL_EXPR As Short = 15
    Public Const LAYER_INFO_LBL_LT As Short = 16
    Public Const LAYER_INFO_LBL_CURFONT As Short = 17
    Public Const LAYER_INFO_LBL_FONT As Short = 18
    Public Const LAYER_INFO_LBL_PARALLEL As Short = 19
    Public Const LAYER_INFO_LBL_POS As Short = 20
    Public Const LAYER_INFO_ARROWS As Short = 21
    Public Const LAYER_INFO_NODES As Short = 22
    Public Const LAYER_INFO_CENTROIDS As Short = 23
    Public Const LAYER_INFO_TYPE As Short = 24
    Public Const LAYER_INFO_LBL_VISIBILITY As Short = 25
    Public Const LAYER_INFO_LBL_ZOOM_MIN As Short = 26
    Public Const LAYER_INFO_LBL_ZOOM_MAX As Short = 27
    Public Const LAYER_INFO_LBL_AUTODISPLAY As Short = 28
    Public Const LAYER_INFO_LBL_OVERLAP As Short = 29
    Public Const LAYER_INFO_LBL_DUPLICATES As Short = 30
    Public Const LAYER_INFO_LBL_OFFSET As Short = 31
    Public Const LAYER_INFO_LBL_MAX As Short = 32
    Public Const LAYER_INFO_LBL_PARTIALSEGS As Short = 33
    Public Const LAYER_INFO_HOTLINK_EXPR As Short = 34
    Public Const LAYER_INFO_HOTLINK_MODE As Short = 35
    Public Const LAYER_INFO_HOTLINK_RELATIVE As Short = 36
    Public Const LAYER_INFO_HOTLINK_COUNT As Short = 37
    Public Const LAYER_INFO_LBL_ORIENTATION As Short = 38
    Public Const LAYER_INFO_LAYER_ALPHA As Short = 39
    Public Const LAYER_INFO_LAYER_TRANSLUCENCY As Short = 40
    Public Const LAYER_INFO_LABEL_ALPHA As Short = 41
    Public Const LAYER_INFO_LAYERLIST_ID As Short = 42
    Public Const LAYER_INFO_PARENT_GROUP_ID As Short = 43

    '----------------------------------------------------------------------------
    ' Values returned by LayerInfo() for LAYER_INFO_LABEL_ORIENTATION and
    ' LABEL_INFO_ORIENTATION.
    '----------------------------------------------------------------------------
    Public Const LAYER_INFO_LABEL_ORIENT_HORIZONTAL As Short = 0
    Public Const LAYER_INFO_LABEL_ORIENT_PARALLEL As Short = 1
    Public Const LAYER_INFO_LABEL_ORIENT_CURVED As Short = 2

    '----------------------------------------------------------------------------
    ' Display Modes, returned by LayerInfo() for LAYER_INFO_DISPLAY
    '----------------------------------------------------------------------------
    Public Const LAYER_INFO_DISPLAY_OFF As Short = 0
    Public Const LAYER_INFO_DISPLAY_GRAPHIC As Short = 1
    Public Const LAYER_INFO_DISPLAY_Public As Short = 2
    Public Const LAYER_INFO_DISPLAY_VALUE As Short = 3

    '----------------------------------------------------------------------------
    ' Label Linetypes, returned by LayerInfo() for LAYER_INFO_LBL_LT
    '----------------------------------------------------------------------------
    Public Const LAYER_INFO_LBL_LT_NONE As Short = 0
    Public Const LAYER_INFO_LBL_LT_SIMPLE As Short = 1
    Public Const LAYER_INFO_LBL_LT_ARROW As Short = 2

    '----------------------------------------------------------------------------
    ' Label Positions, returned by LayerInfo() for LAYER_INFO_LBL_POS
    '----------------------------------------------------------------------------
    Public Const LAYER_INFO_LBL_POS_CC As Short = 0
    Public Const LAYER_INFO_LBL_POS_TL As Short = 1
    Public Const LAYER_INFO_LBL_POS_TC As Short = 2
    Public Const LAYER_INFO_LBL_POS_TR As Short = 3
    Public Const LAYER_INFO_LBL_POS_CL As Short = 4
    Public Const LAYER_INFO_LBL_POS_CR As Short = 5
    Public Const LAYER_INFO_LBL_POS_BL As Short = 6
    Public Const LAYER_INFO_LBL_POS_BC As Short = 7
    Public Const LAYER_INFO_LBL_POS_BR As Short = 8

    '----------------------------------------------------------------------------
    ' Layer Types, returned by LayerInfo() for LAYER_INFO_TYPE
    '----------------------------------------------------------------------------
    Public Const LAYER_INFO_TYPE_NORMAL As Short = 0
    Public Const LAYER_INFO_TYPE_COSMETIC As Short = 1
    Public Const LAYER_INFO_TYPE_IMAGE As Short = 2
    Public Const LAYER_INFO_TYPE_THEMATIC As Short = 3
    Public Const LAYER_INFO_TYPE_GRID As Short = 4
    Public Const LAYER_INFO_TYPE_WMS As Short = 5

    '----------------------------------------------------------------------------
    ' Label visibility modes, from LayerInfo() for LAYER_INFO_LBL_VISIBILITY
    '----------------------------------------------------------------------------
    Public Const LAYER_INFO_LBL_VIS_OFF As Short = 1
    Public Const LAYER_INFO_LBL_VIS_ZOOM As Short = 2
    Public Const LAYER_INFO_LBL_VIS_ON As Short = 3

    '----------------------------------------------------------------------------
    ' HotlinkInfo() defines
    '----------------------------------------------------------------------------
    Public Const HOTLINK_INFO_EXPR As Short = 1
    Public Const HOTLINK_INFO_MODE As Short = 2
    Public Const HOTLINK_INFO_RELATIVE As Short = 3
    Public Const HOTLINK_INFO_ENABLED As Short = 4
    Public Const HOTLINK_INFO_ALIAS As Short = 5

    '----------------------------------------------------------------------------
    ' Hotlink activation modes, from LayerInfo() for LAYER_INFO_HOTLINK_MODE
    '----------------------------------------------------------------------------
    Public Const HOTLINK_MODE_LABEL As Short = 0
    Public Const HOTLINK_MODE_OBJ As Short = 1
    Public Const HOTLINK_MODE_BOTH As Short = 2

    '============================================================================
    ' LegendInfo() defines
    '============================================================================
    Public Const LEGEND_INFO_MAP_ID As Short = 1
    Public Const LEGEND_INFO_ORIENTATION As Short = 2
    Public Const LEGEND_INFO_NUM_FRAMES As Short = 3
    Public Const LEGEND_INFO_STYLE_SAMPLE_SIZE As Short = 4

    '============================================================================
    ' Orientation codes, returned by LegendInfo() for LEGEND_INFO_ORIENTATION
    '============================================================================
    Public Const ORIENTATION_PORTRAIT As Short = 1
    Public Const ORIENTATION_LANDSCAPE As Short = 2
    Public Const ORIENTATION_CUSTOM As Short = 3

    '----------------------------------------------------------------------------
    ' Style sample codes, from LegendInfo() for LEGEND_INFO_STYLE_SAMPLE_SIZE
    '----------------------------------------------------------------------------
    Public Const STYLE_SAMPLE_SIZE_SMALL As Short = 0
    Public Const STYLE_SAMPLE_SIZE_LARGE As Short = 1

    '============================================================================
    ' LegendFrameInfo() defines
    '============================================================================
    Public Const FRAME_INFO_TYPE As Short = 1
    Public Const FRAME_INFO_MAP_LAYER_ID As Short = 2
    Public Const FRAME_INFO_REFRESHABLE As Short = 3
    Public Const FRAME_INFO_POS_X As Short = 4
    Public Const FRAME_INFO_POS_Y As Short = 5
    Public Const FRAME_INFO_WIDTH As Short = 6
    Public Const FRAME_INFO_HEIGHT As Short = 7
    Public Const FRAME_INFO_TITLE As Short = 8
    Public Const FRAME_INFO_TITLE_FONT As Short = 9
    Public Const FRAME_INFO_SUBTITLE As Short = 10
    Public Const FRAME_INFO_SUBTITLE_FONT As Short = 11
    Public Const FRAME_INFO_BORDER_PEN As Short = 12
    Public Const FRAME_INFO_NUM_STYLES As Short = 13
    Public Const FRAME_INFO_VISIBLE As Short = 14
    Public Const FRAME_INFO_COLUMN As Short = 15
    Public Const FRAME_INFO_LABEL As Short = 16

    '============================================================================
    ' Frame Types, returned by LegendFrameInfo() for FRAME_INFO_TYPE
    '============================================================================
    Public Const FRAME_TYPE_STYLE As Short = 1
    Public Const FRAME_TYPE_THEME As Short = 2

    '============================================================================
    ' Geocode Attributes, returned by GeocodeInfo()
    '============================================================================
    Public Const GEOCODE_STREET_NAME As Short = 1
    Public Const GEOCODE_STREET_NUMBER As Short = 2
    Public Const GEOCODE_MUNICIPALITY As Short = 3
    Public Const GEOCODE_MUNICIPALITY2 As Short = 4
    Public Const GEOCODE_COUNTRY_SUBDIVISION As Short = 5
    Public Const GEOCODE_COUNTRY_SUBDIVISION2 As Short = 6
    Public Const GEOCODE_POSTAL_CODE As Short = 7
    Public Const GEOCODE_DICTIONARY As Short = 9
    Public Const GEOCODE_BATCH_SIZE As Short = 10
    Public Const GEOCODE_FALLBACK_GEOGRAPHIC As Short = 11
    Public Const GEOCODE_FALLBACK_POSTAL As Short = 12
    Public Const GEOCODE_OFFSET_CENTER As Short = 13
    Public Const GEOCODE_OFFSET_CENTER_UNITS As Short = 14
    Public Const GEOCODE_OFFSET_END As Short = 15
    Public Const GEOCODE_OFFSET_END_UNITS As Short = 16
    Public Const GEOCODE_MIXED_CASE As Short = 17
    Public Const GEOCODE_RESULT_MARK_MULTIPLE As Short = 18
    Public Const GEOCODE_COUNT_GEOCODED As Short = 19
    Public Const GEOCODE_COUNT_NOTGEOCODED As Short = 20
    Public Const GEOCODE_UNABLE_TO_CONVERT_DATA As Short = 21
    Public Const GEOCODE_MAX_BATCH_SIZE As Short = 22

    Public Const GEOCODE_PASSTHROUGH As Short = 100

    Public Const DICTIONARY_ALL As Short = 1
    Public Const DICTIONARY_ADDRESS_ONLY As Short = 2
    Public Const DICTIONARY_USER_ONLY As Short = 3
    Public Const DICTIONARY_PREFER_ADDRESS As Short = 4
    Public Const DICTIONARY_PREFER_USER As Short = 5

    '============================================================================
    ' ISOGRAM Attributes, returned by IsogramInfo()
    '============================================================================
    Public Const ISOGRAM_BANDING As Short = 1
    Public Const ISOGRAM_MAJOR_ROADS_ONLY As Short = 2
    Public Const ISOGRAM_RETURN_HOLES As Short = 3
    Public Const ISOGRAM_MAJOR_POLYGON_ONLY As Short = 4
    Public Const ISOGRAM_MAX_OFFROAD_DIST As Short = 5
    Public Const ISOGRAM_MAX_OFFROAD_DIST_UNITS As Short = 6
    Public Const ISOGRAM_SIMPLIFICATION_FACTOR As Short = 7
    Public Const ISOGRAM_DEFAULT_AMBIENT_SPEED As Short = 8
    Public Const ISOGRAM_AMBIENT_SPEED_DIST_UNIT As Short = 9
    Public Const ISOGRAM_AMBIENT_SPEED_TIME_UNIT As Short = 10
    Public Const ISOGRAM_PROPAGATION_FACTOR As Short = 11
    Public Const ISOGRAM_BATCH_SIZE As Short = 12
    Public Const ISOGRAM_POINTS_ONLY As Short = 13
    Public Const ISOGRAM_RECORDS_INSERTED As Short = 14
    Public Const ISOGRAM_RECORDS_NOTINSERTED As Short = 15
    Public Const ISOGRAM_MAX_BATCH_SIZE As Short = 16
    Public Const ISOGRAM_MAX_BANDS As Short = 17
    Public Const ISOGRAM_MAX_DISTANCE As Short = 18
    Public Const ISOGRAM_MAX_DISTANCE_UNITS As Short = 19
    Public Const ISOGRAM_MAX_TIME As Short = 20
    Public Const ISOGRAM_MAX_TIME_UNITS As Short = 21

    '============================================================================
    ' LegendStyleInfo() defines
    '============================================================================
    Public Const LEGEND_STYLE_INFO_TEXT As Short = 1
    Public Const LEGEND_STYLE_INFO_FONT As Short = 2
    Public Const LEGEND_STYLE_INFO_OBJ As Short = 3

    '============================================================================
    ' LocateFile$() defines
    '============================================================================

    Public Const LOCATE_PREF_FILE As Short = 0
    Public Const LOCATE_DEF_WOR As Short = 1
    Public Const LOCATE_CLR_FILE As Short = 2
    Public Const LOCATE_PEN_FILE As Short = 3
    Public Const LOCATE_FNT_FILE As Short = 4
    Public Const LOCATE_ABB_FILE As Short = 5
    Public Const LOCATE_PRJ_FILE As Short = 6
    Public Const LOCATE_MNU_FILE As Short = 7
    Public Const LOCATE_CUSTSYMB_DIR As Short = 8
    Public Const LOCATE_THMTMPLT_DIR As Short = 9
    Public Const LOCATE_GRAPH_DIR As Short = 10
    Public Const LOCATE_WMS_SERVERLIST As Short = 11
    Public Const LOCATE_WFS_SERVERLIST As Short = 12
    Public Const LOCATE_GEOCODE_SERVERLIST As Short = 13
    Public Const LOCATE_ROUTING_SERVERLIST As Short = 14
    Public Const LOCATE_LAYOUT_TEMPLATE_DIR As Short = 15

    '============================================================================
    ' Map3DInfo() defines
    '============================================================================
    Public Const MAP3D_INFO_SCALE As Short = 1
    Public Const MAP3D_INFO_RESOLUTION_X As Short = 2
    Public Const MAP3D_INFO_RESOLUTION_Y As Short = 3
    Public Const MAP3D_INFO_BACKGROUND As Short = 4
    Public Const MAP3D_INFO_UNITS As Short = 5
    Public Const MAP3D_INFO_LIGHT_X As Short = 6
    Public Const MAP3D_INFO_LIGHT_Y As Short = 7
    Public Const MAP3D_INFO_LIGHT_Z As Short = 8
    Public Const MAP3D_INFO_LIGHT_COLOR As Short = 9
    Public Const MAP3D_INFO_CAMERA_X As Short = 10
    Public Const MAP3D_INFO_CAMERA_Y As Short = 11
    Public Const MAP3D_INFO_CAMERA_Z As Short = 12
    Public Const MAP3D_INFO_CAMERA_FOCAL_X As Short = 13
    Public Const MAP3D_INFO_CAMERA_FOCAL_Y As Short = 14
    Public Const MAP3D_INFO_CAMERA_FOCAL_Z As Short = 15
    Public Const MAP3D_INFO_CAMERA_VU_1 As Short = 16
    Public Const MAP3D_INFO_CAMERA_VU_2 As Short = 17
    Public Const MAP3D_INFO_CAMERA_VU_3 As Short = 18
    Public Const MAP3D_INFO_CAMERA_VPN_1 As Short = 19
    Public Const MAP3D_INFO_CAMERA_VPN_2 As Short = 20
    Public Const MAP3D_INFO_CAMERA_VPN_3 As Short = 21
    Public Const MAP3D_INFO_CAMERA_CLIP_NEAR As Short = 22
    Public Const MAP3D_INFO_CAMERA_CLIP_FAR As Short = 23

    '============================================================================
    ' MapperInfo() defines
    '============================================================================
    Public Const MAPPER_INFO_ZOOM As Short = 1
    Public Const MAPPER_INFO_SCALE As Short = 2
    Public Const MAPPER_INFO_CENTERX As Short = 3
    Public Const MAPPER_INFO_CENTERY As Short = 4
    Public Const MAPPER_INFO_MINX As Short = 5
    Public Const MAPPER_INFO_MINY As Short = 6
    Public Const MAPPER_INFO_MAXX As Short = 7
    Public Const MAPPER_INFO_MAXY As Short = 8
    Public Const MAPPER_INFO_LAYERS As Short = 9
    Public Const MAPPER_INFO_EDIT_LAYER As Short = 10
    Public Const MAPPER_INFO_XYUNITS As Short = 11
    Public Const MAPPER_INFO_DISTUNITS As Short = 12
    Public Const MAPPER_INFO_AREAUNITS As Short = 13
    Public Const MAPPER_INFO_SCROLLBARS As Short = 14
    Public Const MAPPER_INFO_DISPLAY As Short = 15
    Public Const MAPPER_INFO_NUM_THEMATIC As Short = 16
    Public Const MAPPER_INFO_COORDSYS_CLAUSE As Short = 17
    Public Const MAPPER_INFO_COORDSYS_NAME As Short = 18
    Public Const MAPPER_INFO_MOVE_DUPLICATE_NODES As Short = 19
    Public Const MAPPER_INFO_DIST_CALC_TYPE As Short = 20
    Public Const MAPPER_INFO_DISPLAY_DMS As Short = 21
    Public Const MAPPER_INFO_COORDSYS_CLAUSE_WITH_BOUNDS As Short = 22
    Public Const MAPPER_INFO_CLIP_TYPE As Short = 23
    Public Const MAPPER_INFO_CLIP_REGION As Short = 24
    Public Const MAPPER_INFO_REPROJECTION As Short = 25
    Public Const MAPPER_INFO_RESAMPLING As Short = 26
    Public Const MAPPER_INFO_MERGE_MAP As Short = 27
    Public Const MAPPER_INFO_ALL_LAYERS As Short = 28
    Public Const MAPPER_INFO_GROUPLAYERS As Short = 29
    Public Const MAPPER_INFO_NUM_ADORNMENTS As Short = 200
    Public Const MAPPER_INFO_ADORNMENT As Short = 200
    '----------------------------------------------------------------------------
    ' Display Modes, returned by MapperInfo() for MAPPER_INFO_DISPLAY_DMS
    '----------------------------------------------------------------------------
    Public Const MAPPER_INFO_DISPLAY_DECIMAL As Short = 0
    Public Const MAPPER_INFO_DISPLAY_DEGMINSEC As Short = 1
    Public Const MAPPER_INFO_DISPLAY_MGRS As Short = 2
    Public Const MAPPER_INFO_DISPLAY_USNG_WGS84 As Short = 3
    Public Const MAPPER_INFO_DISPLAY_USNG_NAD27 As Short = 4

    '----------------------------------------------------------------------------
    ' Display Modes, returned by MapperInfo() for MAPPER_INFO_DISPLAY
    '----------------------------------------------------------------------------
    Public Const MAPPER_INFO_DISPLAY_SCALE As Short = 0
    Public Const MAPPER_INFO_DISPLAY_ZOOM As Short = 1
    Public Const MAPPER_INFO_DISPLAY_POSITION As Short = 2

    '----------------------------------------------------------------------------
    ' Distance Calculation Types from MapperInfo() for MAPPER_INFO_DIST_CALC_TYPE
    '----------------------------------------------------------------------------
    Public Const MAPPER_INFO_DIST_SPHERICAL As Short = 0
    Public Const MAPPER_INFO_DIST_CARTESIAN As Short = 1

    '----------------------------------------------------------------------------
    ' Clip Types, returned by MapperInfo() for MAPPER_INFO_CLIP_TYPE
    '----------------------------------------------------------------------------
    Public Const MAPPER_INFO_CLIP_DISPLAY_ALL As Short = 0
    Public Const MAPPER_INFO_CLIP_DISPLAY_POLYOBJ As Short = 1
    Public Const MAPPER_INFO_CLIP_OVERLAY As Short = 2

    '============================================================================
    ' MenuItemInfoByID() and MenuItemInfoByHandler() defines
    '============================================================================
    Public Const MENUITEM_INFO_ENABLED As Short = 1
    Public Const MENUITEM_INFO_CHECKED As Short = 2
    Public Const MENUITEM_INFO_CHECKABLE As Short = 3
    Public Const MENUITEM_INFO_SHOWHIDEABLE As Short = 4
    Public Const MENUITEM_INFO_ACCELERATOR As Short = 5
    Public Const MENUITEM_INFO_TEXT As Short = 6
    Public Const MENUITEM_INFO_HELPMSG As Short = 7
    Public Const MENUITEM_INFO_HANDLER As Short = 8
    Public Const MENUITEM_INFO_ID As Short = 9

    '============================================================================
    ' ObjectGeography() defines
    '============================================================================
    Public Const OBJ_GEO_MINX As Short = 1
    Public Const OBJ_GEO_LINEBEGX As Short = 1
    Public Const OBJ_GEO_POINTX As Short = 1
    Public Const OBJ_GEO_MINY As Short = 2
    Public Const OBJ_GEO_LINEBEGY As Short = 2
    Public Const OBJ_GEO_POINTY As Short = 2
    Public Const OBJ_GEO_MAXX As Short = 3
    Public Const OBJ_GEO_LINEENDX As Short = 3
    Public Const OBJ_GEO_MAXY As Short = 4
    Public Const OBJ_GEO_LINEENDY As Short = 4
    Public Const OBJ_GEO_ARCBEGANGLE As Short = 5
    Public Const OBJ_GEO_TEXTLINEX As Short = 5
    Public Const OBJ_GEO_ROUNDRADIUS As Short = 5
    Public Const OBJ_GEO_CENTROID As Short = 5
    Public Const OBJ_GEO_ARCENDANGLE As Short = 6
    Public Const OBJ_GEO_TEXTLINEY As Short = 6
    Public Const OBJ_GEO_TEXTANGLE As Short = 7
    Public Const OBJ_GEO_POINTZ As Short = 8
    Public Const OBJ_GEO_POINTM As Short = 9

    '============================================================================
    ' ObjectInfo() defines
    '============================================================================
    Public Const OBJ_INFO_TYPE As Short = 1
    Public Const OBJ_INFO_PEN As Short = 2
    Public Const OBJ_INFO_SYMBOL As Short = 2
    Public Const OBJ_INFO_TEXTFONT As Short = 2
    Public Const OBJ_INFO_BRUSH As Short = 3
    Public Const OBJ_INFO_NPNTS As Short = 20
    Public Const OBJ_INFO_TEXTSTRING As Short = 3
    Public Const OBJ_INFO_SMOOTH As Short = 4
    Public Const OBJ_INFO_FRAMEWIN As Short = 4
    Public Const OBJ_INFO_NPOLYGONS As Short = 21
    Public Const OBJ_INFO_TEXTSPACING As Short = 4
    Public Const OBJ_INFO_TEXTJUSTIFY As Short = 5
    Public Const OBJ_INFO_FRAMETITLE As Short = 6
    Public Const OBJ_INFO_TEXTARROW As Short = 6
    Public Const OBJ_INFO_FILLFRAME As Short = 7
    Public Const OBJ_INFO_REGION As Short = 8
    Public Const OBJ_INFO_PLINE As Short = 9
    Public Const OBJ_INFO_MPOINT As Short = 10
    Public Const OBJ_INFO_NONEMPTY As Short = 11
    Public Const OBJ_INFO_Z_UNIT_SET As Short = 12
    Public Const OBJ_INFO_Z_UNIT As Short = 13
    Public Const OBJ_INFO_HAS_Z As Short = 14
    Public Const OBJ_INFO_HAS_M As Short = 15

    '----------------------------------------------------------------------------
    ' Object types, returned by ObjectInfo() for OBJ_INFO_TYPE
    '----------------------------------------------------------------------------
    Public Const OBJ_TYPE_ARC As Short = 1
    Public Const OBJ_TYPE_ELLIPSE As Short = 2
    Public Const OBJ_TYPE_LINE As Short = 3
    Public Const OBJ_TYPE_PLINE As Short = 4
    Public Const OBJ_TYPE_POINT As Short = 5
    Public Const OBJ_TYPE_FRAME As Short = 6
    Public Const OBJ_TYPE_REGION As Short = 7
    Public Const OBJ_TYPE_RECT As Short = 8
    Public Const OBJ_TYPE_ROUNDRECT As Short = 9
    Public Const OBJ_TYPE_TEXT As Short = 10
    Public Const OBJ_TYPE_MPOINT As Short = 11
    Public Const OBJ_TYPE_COLLECTION As Short = 12

    '----------------------------------------------------------------------------
    ' Constants passed to RegionInfo.
    '----------------------------------------------------------------------------
    Public Const REGION_INFO_IS_CLOCKWISE As Short = 1

    '============================================================================
    ' PrismMapInfo() defines
    '============================================================================

    Public Const PRISMMAP_INFO_SCALE As Short = 1
    Public Const PRISMMAP_INFO_BACKGROUND As Short = 4
    Public Const PRISMMAP_INFO_LIGHT_X As Short = 6
    Public Const PRISMMAP_INFO_LIGHT_Y As Short = 7
    Public Const PRISMMAP_INFO_LIGHT_Z As Short = 8
    Public Const PRISMMAP_INFO_LIGHT_COLOR As Short = 9
    Public Const PRISMMAP_INFO_CAMERA_X As Short = 10
    Public Const PRISMMAP_INFO_CAMERA_Y As Short = 11
    Public Const PRISMMAP_INFO_CAMERA_Z As Short = 12
    Public Const PRISMMAP_INFO_CAMERA_FOCAL_X As Short = 13
    Public Const PRISMMAP_INFO_CAMERA_FOCAL_Y As Short = 14
    Public Const PRISMMAP_INFO_CAMERA_FOCAL_Z As Short = 15
    Public Const PRISMMAP_INFO_CAMERA_VU_1 As Short = 16
    Public Const PRISMMAP_INFO_CAMERA_VU_2 As Short = 17
    Public Const PRISMMAP_INFO_CAMERA_VU_3 As Short = 18
    Public Const PRISMMAP_INFO_CAMERA_VPN_1 As Short = 19
    Public Const PRISMMAP_INFO_CAMERA_VPN_2 As Short = 20
    Public Const PRISMMAP_INFO_CAMERA_VPN_3 As Short = 21
    Public Const PRISMMAP_INFO_CAMERA_CLIP_NEAR As Short = 22
    Public Const PRISMMAP_INFO_CAMERA_CLIP_FAR As Short = 23
    Public Const PRISMMAP_INFO_INFOTIP_EXPR As Short = 24

    '============================================================================
    ' SearchInfo() defines
    '============================================================================
    Public Const SEARCH_INFO_TABLE As Short = 1
    Public Const SEARCH_INFO_ROW As Short = 2

    '============================================================================
    ' SelectionInfo() defines
    '============================================================================
    Public Const SEL_INFO_TABLENAME As Short = 1
    Public Const SEL_INFO_SELNAME As Short = 2
    Public Const SEL_INFO_NROWS As Short = 3

    '============================================================================
    ' Server statement and function defines
    '============================================================================
    '----------------------------------------------------------------------------
    ' Return Codes
    '----------------------------------------------------------------------------
    Public Const SRV_SUCCESS As Short = 0
    Public Const SRV_SUCCESS_WITH_INFO As Short = 1
    Public Const SRV_ERROR As Short = -1
    Public Const SRV_INVALID_HANDLE As Short = -2
    Public Const SRV_NEED_DATA As Short = 99
    Public Const SRV_NO_MORE_DATA As Short = 100

    '----------------------------------------------------------------------------
    ' Special values for the status associated with a fetched value
    '----------------------------------------------------------------------------
    Public Const SRV_NULL_DATA As Short = -1
    Public Const SRV_TRUNCATED_DATA As Short = -2

    '----------------------------------------------------------------------------
    ' Server_ColumnInfo() defines
    '----------------------------------------------------------------------------
    Public Const SRV_COL_INFO_NAME As Short = 1
    Public Const SRV_COL_INFO_TYPE As Short = 2
    Public Const SRV_COL_INFO_WIDTH As Short = 3
    Public Const SRV_COL_INFO_PRECISION As Short = 4
    Public Const SRV_COL_INFO_SCALE As Short = 5
    Public Const SRV_COL_INFO_VALUE As Short = 6
    Public Const SRV_COL_INFO_STATUS As Short = 7
    Public Const SRV_COL_INFO_ALIAS As Short = 8

    '----------------------------------------------------------------------------
    ' Column types, returned by Server_ColumnInfo() for SRV_COL_INFO_TYPE
    '----------------------------------------------------------------------------
    Public Const SRV_COL_TYPE_NONE As Short = 0
    Public Const SRV_COL_TYPE_CHAR As Short = 1
    Public Const SRV_COL_TYPE_DECIMAL As Short = 2
    Public Const SRV_COL_TYPE_INTEGER As Short = 3
    Public Const SRV_COL_TYPE_SMALLINT As Short = 4
    Public Const SRV_COL_TYPE_DATE As Short = 5
    Public Const SRV_COL_TYPE_LOGICAL As Short = 6
    Public Const SRV_COL_TYPE_FLOAT As Short = 8
    Public Const SRV_COL_TYPE_FIXED_LEN_STRING As Short = 16
    Public Const SRV_COL_TYPE_BIN_STRING As Short = 17

    '----------------------------------------------------------------------------
    ' Server_DriverInfo() Attr defines
    '----------------------------------------------------------------------------
    Public Const SRV_DRV_INFO_NAME As Short = 1
    Public Const SRV_DRV_INFO_NAME_LIST As Short = 2
    Public Const SRV_DRV_DATA_SOURCE As Short = 3

    '----------------------------------------------------------------------------
    ' Server_ConnectInfo() Attr defines
    '----------------------------------------------------------------------------
    Public Const SRV_CONNECT_INFO_DRIVER_NAME As Short = 1
    Public Const SRV_CONNECT_INFO_DB_NAME As Short = 2
    Public Const SRV_CONNECT_INFO_SQL_USER_ID As Short = 3
    Public Const SRV_CONNECT_INFO_DS_NAME As Short = 4
    Public Const SRV_CONNECT_INFO_QUOTE_CHAR As Short = 5

    '----------------------------------------------------------------------------
    ' Fetch Directions (used by ServerFetch function in some code libraries)
    '----------------------------------------------------------------------------
    Public Const SRV_FETCH_NEXT As Short = -1
    Public Const SRV_FETCH_PREV As Short = -2
    Public Const SRV_FETCH_FIRST As Short = -3
    Public Const SRV_FETCH_LAST As Short = -4

    '----------------------------------------------------------------------------
    'Oracle workspace manager
    '----------------------------------------------------------------------------
    Public Const SRV_WM_HIST_NONE As Short = 0
    Public Const SRV_WM_HIST_OVERWRITE As Short = 1
    Public Const SRV_WM_HIST_NO_OVERWRITE As Short = 2

    '============================================================================
    ' SessionInfo() defines
    '============================================================================

    Public Const SESSION_INFO_COORDSYS_CLAUSE As Short = 1
    Public Const SESSION_INFO_DISTANCE_UNITS As Short = 2
    Public Const SESSION_INFO_AREA_UNITS As Short = 3
    Public Const SESSION_INFO_PAPER_UNITS As Short = 4

    '============================================================================
    ' Set Next Document Style defines
    '============================================================================
    Public Const WIN_STYLE_STANDARD As Short = 0
    Public Const WIN_STYLE_CHILD As Short = 1
    Public Const WIN_STYLE_POPUP_FULLCAPTION As Short = 2
    Public Const WIN_STYLE_POPUP As Short = 3

    '============================================================================
    ' StringCompare() defines
    '============================================================================
    Public Const STR_LT As Short = -1
    Public Const STR_GT As Short = 1
    Public Const STR_EQ As Short = 0

    '============================================================================
    ' StyleAttr() defines
    '============================================================================
    Public Const PEN_WIDTH As Short = 1
    Public Const PEN_PATTERN As Short = 2
    Public Const PEN_COLOR As Short = 4
    Public Const PEN_INDEX As Short = 5
    Public Const PEN_INTERLEAVED As Short = 6
    Public Const BRUSH_PATTERN As Short = 1
    Public Const BRUSH_FORECOLOR As Short = 2
    Public Const BRUSH_BACKCOLOR As Short = 3
    Public Const FONT_NAME As Short = 1
    Public Const FONT_STYLE As Short = 2
    Public Const FONT_POINTSIZE As Short = 3
    Public Const FONT_FORECOLOR As Short = 4
    Public Const FONT_BACKCOLOR As Short = 5
    Public Const SYMBOL_CODE As Short = 1
    Public Const SYMBOL_COLOR As Short = 2
    Public Const SYMBOL_POINTSIZE As Short = 3
    Public Const SYMBOL_ANGLE As Short = 4
    Public Const SYMBOL_FONT_NAME As Short = 5
    Public Const SYMBOL_FONT_STYLE As Short = 6
    Public Const SYMBOL_KIND As Short = 7
    Public Const SYMBOL_CUSTOM_NAME As Short = 8
    Public Const SYMBOL_CUSTOM_STYLE As Short = 9

    '----------------------------------------------------------------------------
    ' Symbol kinds returned by StyleAttr() for SYMBOL_KIND
    '----------------------------------------------------------------------------
    Public Const SYMBOL_KIND_VECTOR As Short = 1
    Public Const SYMBOL_KIND_FONT As Short = 2
    Public Const SYMBOL_KIND_CUSTOM As Short = 3

    '============================================================================
    ' SystemInfo() defines
    '============================================================================
    Public Const SYS_INFO_PLATFORM As Short = 1
    Public Const SYS_INFO_APPVERSION As Short = 2
    Public Const SYS_INFO_MIVERSION As Short = 3
    Public Const SYS_INFO_RUNTIME As Short = 4
    Public Const SYS_INFO_CHARSET As Short = 5
    Public Const SYS_INFO_COPYPROTECTED As Short = 6
    Public Const SYS_INFO_APPLICATIONWND As Short = 7
    Public Const SYS_INFO_DDESTATUS As Short = 8
    Public Const SYS_INFO_MAPINFOWND As Short = 9
    Public Const SYS_INFO_NUMBER_FORMAT As Short = 10
    Public Const SYS_INFO_DATE_FORMAT As Short = 11
    Public Const SYS_INFO_DIG_INSTALLED As Short = 12
    Public Const SYS_INFO_DIG_MODE As Short = 13
    Public Const SYS_INFO_MIPLATFORM As Short = 14
    Public Const SYS_INFO_MDICLIENTWND As Short = 15
    Public Const SYS_INFO_PRODUCTLEVEL As Short = 16
    Public Const SYS_INFO_APPIDISPATCH As Short = 17
    Public Const SYS_INFO_MIBUILD_NUMBER As Short = 18

    '----------------------------------------------------------------------------
    ' Platform, returned by SystemInfo() for SYS_INFO_PLATFORM
    '----------------------------------------------------------------------------
    Public Const PLATFORM_SPECIAL As Short = 0
    Public Const PLATFORM_WIN As Short = 1
    Public Const PLATFORM_MAC As Short = 2
    Public Const PLATFORM_MOTIF As Short = 3
    Public Const PLATFORM_X11 As Short = 4
    Public Const PLATFORM_XOL As Short = 5

    '----------------------------------------------------------------------------
    ' Version, returned by SystemInfo() for SYS_INFO_MIPLATFORM
    '----------------------------------------------------------------------------
    Public Const MIPLATFORM_SPECIAL As Short = 0
    Public Const MIPLATFORM_WIN16 As Short = 1
    Public Const MIPLATFORM_WIN32 As Short = 2
    Public Const MIPLATFORM_POWERMAC As Short = 3
    Public Const MIPLATFORM_MAC68K As Short = 4
    Public Const MIPLATFORM_HP As Short = 5
    Public Const MIPLATFORM_SUN As Short = 6

    '============================================================================
    ' TableInfo() defines
    '============================================================================
    Public Const TAB_INFO_NAME As Short = 1
    Public Const TAB_INFO_NUM As Short = 2
    Public Const TAB_INFO_TYPE As Short = 3
    Public Const TAB_INFO_NCOLS As Short = 4
    Public Const TAB_INFO_MAPPABLE As Short = 5
    Public Const TAB_INFO_READONLY As Short = 6
    Public Const TAB_INFO_TEMP As Short = 7
    Public Const TAB_INFO_NROWS As Short = 8
    Public Const TAB_INFO_EDITED As Short = 9
    Public Const TAB_INFO_FASTEDIT As Short = 10
    Public Const TAB_INFO_UNDO As Short = 11
    Public Const TAB_INFO_MAPPABLE_TABLE As Short = 12
    Public Const TAB_INFO_USERMAP As Short = 13
    Public Const TAB_INFO_USERBROWSE As Short = 14
    Public Const TAB_INFO_USERCLOSE As Short = 15
    Public Const TAB_INFO_USEREDITABLE As Short = 16
    Public Const TAB_INFO_USERREMOVEMAP As Short = 17
    Public Const TAB_INFO_USERDISPLAYMAP As Short = 18
    Public Const TAB_INFO_TABFILE As Short = 19
    Public Const TAB_INFO_MINX As Short = 20
    Public Const TAB_INFO_MINY As Short = 21
    Public Const TAB_INFO_MAXX As Short = 22
    Public Const TAB_INFO_MAXY As Short = 23
    Public Const TAB_INFO_SEAMLESS As Short = 24
    Public Const TAB_INFO_COORDSYS_MINX As Short = 25
    Public Const TAB_INFO_COORDSYS_MINY As Short = 26
    Public Const TAB_INFO_COORDSYS_MAXX As Short = 27
    Public Const TAB_INFO_COORDSYS_MAXY As Short = 28
    Public Const TAB_INFO_COORDSYS_CLAUSE As Short = 29
    Public Const TAB_INFO_COORDSYS_NAME As Short = 30
    Public Const TAB_INFO_NREFS As Short = 31
    Public Const TAB_INFO_SUPPORT_MZ As Short = 32
    Public Const TAB_INFO_Z_UNIT_SET As Short = 33
    Public Const TAB_INFO_Z_UNIT As Short = 34
    Public Const TAB_INFO_BROWSER_LIST As Short = 35
    Public Const TAB_INFO_THEME_METADATA As Short = 36
    Public Const TAB_INFO_COORDSYS_CLAUSE_WITHOUT_BOUNDS As Short = 37

    '----------------------------------------------------------------------------
    ' Table type defines, returned by TableInfo() for TAB_INFO_TYPE
    '----------------------------------------------------------------------------
    Public Const TAB_TYPE_BASE As Short = 1
    Public Const TAB_TYPE_RESULT As Short = 2
    Public Const TAB_TYPE_VIEW As Short = 3
    Public Const TAB_TYPE_IMAGE As Short = 4
    Public Const TAB_TYPE_LINKED As Short = 5
    Public Const TAB_TYPE_WMS As Short = 6
    Public Const TAB_TYPE_WFS As Short = 7
    Public Const TAB_TYPE_FME As Short = 8

    '============================================================================
    ' RasterTableInfo() defines
    '============================================================================
    Public Const RASTER_TAB_INFO_IMAGE_NAME As Short = 1
    Public Const RASTER_TAB_INFO_WIDTH As Short = 2
    Public Const RASTER_TAB_INFO_HEIGHT As Short = 3
    Public Const RASTER_TAB_INFO_IMAGE_TYPE As Short = 4
    Public Const RASTER_TAB_INFO_BITS_PER_PIXEL As Short = 5
    Public Const RASTER_TAB_INFO_IMAGE_CLASS As Short = 6
    Public Const RASTER_TAB_INFO_NUM_CONTROL_POINTS As Short = 7
    Public Const RASTER_TAB_INFO_BRIGHTNESS As Short = 8
    Public Const RASTER_TAB_INFO_CONTRAST As Short = 9
    Public Const RASTER_TAB_INFO_GREYSCALE As Short = 10
    Public Const RASTER_TAB_INFO_DISPLAY_TRANSPARENT As Short = 11
    Public Const RASTER_TAB_INFO_TRANSPARENT_COLOR As Short = 12
    Public Const RASTER_TAB_INFO_ALPHA As Short = 13

    '----------------------------------------------------------------------------
    ' Image type defines returned by RasterTableInfo() for RASTER_TAB_INFO_IMAGE_TYPE
    '----------------------------------------------------------------------------
    Public Const IMAGE_TYPE_RASTER As Short = 0
    Public Const IMAGE_TYPE_GRID As Short = 1

    '----------------------------------------------------------------------------
    ' Image class defines returned by RasterTableInfo() for RASTER_TAB_INFO_IMAGE_CLASS
    '----------------------------------------------------------------------------
    Public Const IMAGE_CLASS_BILEVEL As Short = 0
    Public Const IMAGE_CLASS_GREYSCALE As Short = 1
    Public Const IMAGE_CLASS_PALETTE As Short = 2
    Public Const IMAGE_CLASS_RGB As Short = 3

    '============================================================================
    '  GridTableInfo() defines
    '============================================================================
    Public Const GRID_TAB_INFO_MIN_VALUE As Short = 1
    Public Const GRID_TAB_INFO_MAX_VALUE As Short = 2
    Public Const GRID_TAB_INFO_HAS_HILLSHADE As Short = 3

    '============================================================================
    '  ControlPointInfo() defines
    '============================================================================
    Public Const RASTER_CONTROL_POINT_X As Short = 1
    Public Const RASTER_CONTROL_POINT_Y As Short = 2
    Public Const GEO_CONTROL_POINT_X As Short = 3
    Public Const GEO_CONTROL_POINT_Y As Short = 4
    Public Const TAB_GEO_CONTROL_POINT_X As Short = 5
    Public Const TAB_GEO_CONTROL_POINT_Y As Short = 6

    '============================================================================
    ' WindowInfo() defines
    '============================================================================
    Public Const WIN_INFO_NAME As Short = 1
    Public Const WIN_INFO_TYPE As Short = 3
    Public Const WIN_INFO_WIDTH As Short = 4
    Public Const WIN_INFO_HEIGHT As Short = 5
    Public Const WIN_INFO_X As Short = 6
    Public Const WIN_INFO_Y As Short = 7
    Public Const WIN_INFO_TOPMOST As Short = 8
    Public Const WIN_INFO_STATE As Short = 9
    Public Const WIN_INFO_TABLE As Short = 10
    Public Const WIN_INFO_LEGENDS_MAP As Short = 10
    Public Const WIN_INFO_ADORNMENTS_MAP As Short = 10
    Public Const WIN_INFO_OPEN As Short = 11
    Public Const WIN_INFO_WND As Short = 12
    Public Const WIN_INFO_WINDOWID As Short = 13
    Public Const WIN_INFO_WORKSPACE As Short = 14
    Public Const WIN_INFO_CLONEWINDOW As Short = 15
    Public Const WIN_INFO_SYSMENUCLOSE As Short = 16
    Public Const WIN_INFO_AUTOSCROLL As Short = 17
    Public Const WIN_INFO_SMARTPAN As Short = 18
    Public Const WIN_INFO_SNAPMODE As Short = 19
    Public Const WIN_INFO_SNAPTHRESHOLD As Short = 20
    Public Const WIN_INFO_PRINTER_NAME As Short = 21
    Public Const WIN_INFO_PRINTER_ORIENT As Short = 22
    Public Const WIN_INFO_PRINTER_COPIES As Short = 23
    Public Const WIN_INFO_PRINTER_PAPERSIZE As Short = 24
    Public Const WIN_INFO_PRINTER_LEFTMARGIN As Short = 25
    Public Const WIN_INFO_PRINTER_RIGHTMARGIN As Short = 26
    Public Const WIN_INFO_PRINTER_TOPMARGIN As Short = 27
    Public Const WIN_INFO_PRINTER_BOTTOMMARGIN As Short = 28
    Public Const WIN_INFO_PRINTER_BORDER As Short = 29
    Public Const WIN_INFO_PRINTER_TRUECOLOR As Short = 30
    Public Const WIN_INFO_PRINTER_DITHER As Short = 31
    Public Const WIN_INFO_PRINTER_METHOD As Short = 32
    Public Const WIN_INFO_PRINTER_TRANSPRASTER As Short = 33
    Public Const WIN_INFO_PRINTER_TRANSPVECTOR As Short = 34
    Public Const WIN_INFO_EXPORT_BORDER As Short = 35
    Public Const WIN_INFO_EXPORT_TRUECOLOR As Short = 36
    Public Const WIN_INFO_EXPORT_DITHER As Short = 37
    Public Const WIN_INFO_EXPORT_TRANSPRASTER As Short = 38
    Public Const WIN_INFO_EXPORT_TRANSPVECTOR As Short = 39
    Public Const WIN_INFO_PRINTER_SCALE_PATTERNS As Short = 40
    Public Const WIN_INFO_EXPORT_ANTIALIASING As Short = 41
    Public Const WIN_INFO_EXPORT_THRESHOLD As Short = 42
    Public Const WIN_INFO_EXPORT_MASKSIZE As Short = 43
    Public Const WIN_INFO_EXPORT_FILTER As Short = 44
    Public Const WIN_INFO_ENHANCED_RENDERING As Short = 45
    Public Const WIN_INFO_SMOOTH_TEXT As Short = 46
    Public Const WIN_INFO_SMOOTH_IMAGE As Short = 47
    Public Const WIN_INFO_SMOOTH_VECTOR As Short = 48

    '----------------------------------------------------------------------------
    ' Window types, returned by WindowInfo() for WIN_INFO_TYPE
    '----------------------------------------------------------------------------
    Public Const WIN_MAPPER As Short = 1
    Public Const WIN_BROWSER As Short = 2
    Public Const WIN_LAYOUT As Short = 3
    Public Const WIN_GRAPH As Short = 4
    Public Const WIN_BUTTONPAD As Short = 19
    Public Const WIN_TOOLBAR As Short = 25
    Public Const WIN_CART_LEGEND As Short = 27
    Public Const WIN_3DMAP As Short = 28
    Public Const WIN_ADORNMENT As Short = 32
    Public Const WIN_HELP As Short = 1001
    Public Const WIN_MAPBASIC As Short = 1002
    Public Const WIN_MESSAGE As Short = 1003
    Public Const WIN_RULER As Short = 1007
    Public Const WIN_INFO As Short = 1008
    Public Const WIN_LEGEND As Short = 1009
    Public Const WIN_STATISTICS As Short = 1010
    Public Const WIN_MAPINFO As Short = 1011
    '----------------------------------------------------------------------------
    ' Version 2 window types no longer used in version 3 or later versions
    '----------------------------------------------------------------------------
    Public Const WIN_TOOLPICKER As Short = 1004
    Public Const WIN_PENPICKER As Short = 1005
    Public Const WIN_SYMBOLPICKER As Short = 1006

    '----------------------------------------------------------------------------
    ' Window states, returned by WindowInfo() for WIN_INFO_STATE
    '----------------------------------------------------------------------------
    Public Const WIN_STATE_NORMAL As Short = 0
    Public Const WIN_STATE_MINIMIZED As Short = 1
    Public Const WIN_STATE_MAXIMIZED As Short = 2

    '----------------------------------------------------------------------------
    ' Print orientation, returned by WindowInfo() for WIN_INFO_PRINTER_ORIENT
    '----------------------------------------------------------------------------
    Public Const WIN_PRINTER_PORTRAIT As Short = 1
    Public Const WIN_PRINTER_LANDSCAPE As Short = 2

    '----------------------------------------------------------------------------
    ' Antialiasing filters, returned by WindowInfo() for WIN_INFO_EXPORT_FILTER
    '----------------------------------------------------------------------------
    Public Const FILTER_VERTICALLY_AND_HORIZONTALLY As Short = 0
    Public Const FILTER_ALL_DIRECTIONS_1 As Short = 1
    Public Const FILTER_ALL_DIRECTIONS_2 As Short = 2
    Public Const FILTER_DIAGONALLY As Short = 3
    Public Const FILTER_HORIZONTALLY As Short = 4
    Public Const FILTER_VERTICALLY As Short = 5

    '============================================================================
    ' end of MAPBASIC.DEF
    '============================================================================

    '============================================================================
    ' MapInfo version 9.5 - Menu Item Definitions
    '----------------------------------------------------------------------------
    ' This file contains defines useful when programming in the MapBasic
    ' language.  The definitions in this file describe the standard MapInfo
    ' functionality available via the "Run Menu Command" MapBasic statement.
    '----------------------------------------------------------------------------
    ' The defines in this file are organized to match the sequence of
    ' declarations in the MAPINFOW.MNU file, which in turn reflects the
    ' organization of the MapInfo menus and buttonpads.
    '============================================================================

    '----------------------------------------------------------------------------
    ' File menu
    '----------------------------------------------------------------------------
    Public Const M_FILE_NEW As Short = 101
    Public Const M_FILE_OPEN As Short = 102
    Public Const M_FILE_OPEN_WMS As Short = 118
    Public Const M_FILE_OPEN_WFS As Short = 119
    Public Const M_FILE_OPEN_ODBC_CONN As Short = 125
    Public Const M_FILE_OPEN_UNIVERSAL_DATA As Short = 126
    Public Const M_FILE_CLOSE As Short = 103
    Public Const M_FILE_CLOSE_ALL As Short = 104
    Public Const M_FILE_CLOSE_ODBC As Short = 124
    Public Const M_FILE_SAVE As Short = 105
    Public Const M_FILE_SAVE_COPY_AS As Short = 106
    Public Const M_FILE_SAVE_QUERY As Short = 117
    Public Const M_FILE_SAVE_WORKSPACE As Short = 109
    Public Const M_FILE_SAVE_WINDOW_AS As Short = 609
    Public Const M_FILE_REVERT As Short = 107
    Public Const M_FILE_PAGE_SETUP As Short = 111
    Public Const M_FILE_PRINT As Short = 112
    Public Const M_FILE_EXIT As Short = 113

    '----------------------------------------------------------------------------
    ' Edit menu
    '----------------------------------------------------------------------------
    Public Const M_EDIT_UNDO As Short = 201
    Public Const M_EDIT_CUT As Short = 202
    Public Const M_EDIT_COPY As Short = 203
    Public Const M_EDIT_PASTE As Short = 204
    Public Const M_EDIT_CLEAR As Short = 205
    Public Const M_EDIT_CLEAROBJ As Short = 206
    Public Const M_EDIT_RESHAPE As Short = 1601
    Public Const M_EDIT_NEW_ROW As Short = 702
    Public Const M_EDIT_GETINFO As Short = 207

    '----------------------------------------------------------------------------
    ' Tools menu
    '----------------------------------------------------------------------------
    Public Const M_TOOLS_CRYSTAL_REPORTS_NEW As Short = 1802
    Public Const M_TOOLS_CRYSTAL_REPORTS_OPEN As Short = 1803
    Public Const M_TOOLS_RUN As Short = 110
    Public Const M_TOOLS_TOOL_MANAGER As Short = 1801

    '----------------------------------------------------------------------------
    ' Objects menu
    '----------------------------------------------------------------------------
    Public Const M_OBJECTS_SET_TARGET As Short = 1610
    Public Const M_OBJECTS_CLEAR_TARGET As Short = 1611
    Public Const M_OBJECTS_COMBINE As Short = 1605
    Public Const M_OBJECTS_DISAGG As Short = 1621
    Public Const M_OBJECTS_BUFFER As Short = 1606
    Public Const M_OBJECTS_CONVEX_HULL As Short = 1616
    Public Const M_OBJECTS_ENCLOSE As Short = 1617
    Public Const M_OBJECTS_VORONOI As Short = 1622
    Public Const M_OBJECTS_SPLIT As Short = 1612
    Public Const M_OBJECTS_ERASE As Short = 1613
    Public Const M_OBJECTS_ERASE_OUT As Short = 1614
    Public Const M_OBJECTS_POLYLINE_SPLIT As Short = 1623
    Public Const M_OBJECTS_POLYLINE_SPLIT_AT_NODE As Short = 1626
    Public Const M_OBJECTS_DRIVE_REGION As Short = 1627
    Public Const M_OBJECTS_OVERLAY As Short = 1615
    Public Const M_OBJECTS_CHECK_REGIONS As Short = 1618
    Public Const M_OBJECTS_CLEAN As Short = 1619
    Public Const M_OBJECTS_SNAP As Short = 1620
    Public Const M_OBJECTS_OFFSET As Short = 1624
    Public Const M_OBJECTS_ROTATE As Short = 1625
    Public Const M_OBJECTS_SMOOTH As Short = 1602
    Public Const M_OBJECTS_UNSMOOTH As Short = 1603
    Public Const M_OBJECTS_CVT_PGON As Short = 1607
    Public Const M_OBJECTS_CVT_PLINE As Short = 1604

    '----------------------------------------------------------------------------
    ' Query menu
    '----------------------------------------------------------------------------
    Public Const M_QUERY_SELECT As Short = 301
    Public Const M_QUERY_SQLQUERY As Short = 302
    Public Const M_QUERY_SELECTALL As Short = 303
    Public Const M_QUERY_INVERTSELECT As Short = 311
    Public Const M_QUERY_UNSELECT As Short = 304
    Public Const M_QUERY_FIND As Short = 305
    Public Const M_QUERY_FIND_SELECTION As Short = 306
    Public Const M_QUERY_CALC_STATISTICS As Short = 309
    Public Const M_QUERY_FIND_SELECTION_CURRENT_MAP As Short = 312
    Public Const M_QUERY_FIND_ADDRESS As Short = 313

    '----------------------------------------------------------------------------
    ' Table, Maintenance, and Raster menus
    '----------------------------------------------------------------------------
    Public Const M_TABLE_UPDATE_COLUMN As Short = 405
    Public Const M_TABLE_APPEND As Short = 411
    Public Const M_TABLE_GEOCODE As Short = 407
    Public Const M_TABLE_CREATE_POINTS As Short = 408
    Public Const M_TABLE_MERGE_USING_COLUMN As Short = 406
    Public Const M_TABLE_BUFFER As Short = 419
    Public Const M_TABLE_VORONOI As Short = 420
    Public Const M_TABLE_IMPORT As Short = 401
    Public Const M_TABLE_EXPORT As Short = 402

    Public Const M_TABLE_MODIFY_STRUCTURE As Short = 404
    Public Const M_TABLE_DELETE As Short = 409
    Public Const M_TABLE_RENAME As Short = 410
    Public Const M_TABLE_PACK As Short = 403
    Public Const M_TABLE_MAKEMAPPABLE As Short = 415
    Public Const M_TABLE_CHANGESYMBOL As Short = 418
    Public Const M_TABLE_UNLINK As Short = 416
    Public Const M_TABLE_REFRESH As Short = 417

    Public Const M_TABLE_RASTER_STYLE As Short = 414
    Public Const M_TABLE_RASTER_REG As Short = 413
    Public Const M_TOOLS_RASTER_REG As Short = 1730
    Public Const M_TABLE_WMS_PROPS As Short = 421
    Public Const M_TABLE_WFS_REFRESH As Short = 422
    Public Const M_TABLE_WFS_PROPS As Short = 423
    Public Const M_TABLE_WEB_GEOCODE As Short = 424
    Public Const M_TABLE_DRIVE_REGION As Short = 425
    Public Const M_TABLE_UNIVERSAL_DATA_REFRESH As Short = 426

    Public Const M_ORACLE_CREATE_WORKSPACE As Short = 1804
    Public Const M_ORACLE_DELETE_WORKSPACE As Short = 1805
    Public Const M_ORACLE_VERSION_ENABLE_ON As Short = 1806
    Public Const M_ORACLE_VERSION_ENABLE_OFF As Short = 1807
    Public Const M_ORACLE_MERGE_PARENT As Short = 1808
    Public Const M_ORACLE_REFRESH_FROM_PARENT As Short = 1809

    '----------------------------------------------------------------------------
    ' Options and Preferences menus
    '----------------------------------------------------------------------------
    Public Const M_FORMAT_PICK_LINE As Short = 501
    Public Const M_FORMAT_PICK_FILL As Short = 502
    Public Const M_FORMAT_PICK_SYMBOL As Short = 503
    Public Const M_FORMAT_PICK_FONT As Short = 504
    Public Const M_WINDOW_BUTTONPAD As Short = 605
    Public Const M_WINDOW_LEGEND As Short = 606
    Public Const M_WINDOW_STATISTICS As Short = 607
    Public Const M_WINDOW_MAPBASIC As Short = 608
    Public Const M_WINDOW_STATUSBAR As Short = 616
    Public Const M_FORMAT_CUSTOM_COLORS As Short = 617
    Public Const M_EDIT_PREFERENCES As Short = 208

    Public Const M_EDIT_PREFERENCES_SYSTEM As Short = 210
    Public Const M_EDIT_PREFERENCES_MAP As Short = 212
    Public Const M_EDIT_PREFERENCES_LEGEND As Short = 215
    Public Const M_EDIT_PREFERENCES_FILE As Short = 211
    Public Const M_EDIT_PREFERENCES_COUNTRY As Short = 213
    Public Const M_EDIT_PREFERENCES_PATH As Short = 214
    Public Const M_EDIT_PREFERENCES_OUTPUT As Short = 216
    Public Const M_EDIT_PREFERENCES_PRINTER As Short = 217
    Public Const M_EDIT_PREFERENCES_STYLES As Short = 218
    Public Const M_EDIT_PREFERENCES_IMAGE_PROC As Short = 219
    Public Const M_EDIT_PREFERENCES_WEBSERVICES As Short = 220
    Public Const M_EDIT_PREFERENCES_LAYOUT As Short = 221

    '----------------------------------------------------------------------------
    ' Window menu
    '----------------------------------------------------------------------------
    Public Const M_WINDOW_BROWSE As Short = 601
    Public Const M_WINDOW_MAP As Short = 602
    Public Const M_WINDOW_GRAPH As Short = 603
    Public Const M_WINDOW_LAYOUT As Short = 604
    Public Const M_WINDOW_REDISTRICT As Short = 615
    Public Const M_WINDOW_REDRAW As Short = 610
    Public Const M_WINDOW_TILE As Short = 611
    Public Const M_WINDOW_CASCADE As Short = 612
    Public Const M_WINDOW_ARRANGEICONS As Short = 613
    Public Const M_WINDOW_MORE As Short = 614
    Public Const M_WINDOW_FIRST As Short = 620
    ' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
    ' Note: the 2nd through 80th windows can be accessed as (M_WINDOW_FIRST+i-1)
    ' - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

    '----------------------------------------------------------------------------
    ' Help menu
    '----------------------------------------------------------------------------
    Public Const M_HELP_CONTEXTSENSITIVE As Short = 1201
    Public Const M_HELP_CONTENTS As Short = 1202
    Public Const M_HELP_SEARCH As Short = 1203
    Public Const M_HELP_USE_HELP As Short = 1204
    Public Const M_HELP_ABOUT As Short = 1205
    Public Const M_HELP_HELPMODE As Short = 1206
    Public Const M_HELP_TECHSUPPORT As Short = 1208
    Public Const M_HELP_CONNECT_MIFORUM As Short = 1209
    Public Const M_HELP_MAPINFO_WWW As Short = 1210
    Public Const M_HELP_MAPINFO_WWW_STORE As Short = 1211
    Public Const M_HELP_CHECK_FOR_UPDATE As Short = 1212
    Public Const M_HELP_MAPINFO_WWW_TUTORIAL As Short = 1213
    Public Const M_HELP_MAPINFO_3DGRAPH_HELP As Short = 1214
    Public Const M_HELP_MAPINFO_CONNECT_SERVICES As Short = 1215

    '----------------------------------------------------------------------------
    ' Browse menu
    '----------------------------------------------------------------------------
    Public Const M_BROWSE_PICK_FIELDS As Short = 704
    Public Const M_BROWSE_OPTIONS As Short = 703

    '----------------------------------------------------------------------------
    ' Map menu
    '----------------------------------------------------------------------------
    Public Const M_MAP_LAYER_CONTROL As Short = 801
    Public Const M_MAP_CREATE_3DMAP As Short = 817
    Public Const M_MAP_CREATE_PRISMMAP As Short = 818
    Public Const M_MAP_THEMATIC As Short = 307
    Public Const M_MAP_MODIFY_THEMATIC As Short = 308
    Public Const M_MAP_CREATE_LEGEND As Short = 816
    Public Const M_MAP_CHANGE_VIEW As Short = 805
    Public Const M_MAP_CLONE_MAPPER As Short = 811
    Public Const M_MAP_PREVIOUS As Short = 806
    Public Const M_MAP_ENTIRE_LAYER As Short = 807
    Public Const M_MAP_CLEAR_CUSTOM_LABELS As Short = 814
    Public Const M_MAP_SAVE_COSMETIC As Short = 809
    Public Const M_MAP_CLEAR_COSMETIC As Short = 810
    Public Const M_MAP_SET_CLIP_REGION As Short = 812
    Public Const M_MAP_CLIP_REGION_ONOFF As Short = 813
    Public Const M_MAP_SETUPDIGITIZER As Short = 803
    Public Const M_MAP_OPTIONS As Short = 802

    '----------------------------------------------------------------------------
    ' Layout menu
    '----------------------------------------------------------------------------
    Public Const M_LAYOUT_CHANGE_VIEW As Short = 902
    Public Const M_LAYOUT_ACTUAL As Short = 903
    Public Const M_LAYOUT_ENTIRE As Short = 904
    Public Const M_LAYOUT_PREVIOUS As Short = 905
    Public Const M_LAYOUT_BRING2FRONT As Short = 906
    Public Const M_LAYOUT_SEND2BACK As Short = 907
    Public Const M_LAYOUT_ALIGN As Short = 908
    Public Const M_LAYOUT_DROPSHADOWS As Short = 909
    Public Const M_LAYOUT_DISPLAYOPTIONS As Short = 901
    Public Const M_LAYOUT_AUTOSCROLL_ONOFF As Short = 910

    '----------------------------------------------------------------------------
    ' Graph menu
    '----------------------------------------------------------------------------
    Public Const M_GRAPH_TYPE As Short = 1001
    Public Const M_GRAPH_LABEL_AXIS As Short = 1002
    Public Const M_GRAPH_VALUE_AXIS As Short = 1003
    Public Const M_GRAPH_SERIES As Short = 1004

    '----------------------------------------------------------------------------
    ' New Graph menu
    '----------------------------------------------------------------------------
    Public Const M_GRAPH_FORMATING As Short = 2007
    Public Const M_GRAPH_GENERAL_OPTIONS As Short = 2002
    Public Const M_GRAPH_SERIES_OPTIONS As Short = 2003
    Public Const M_GRAPH_GRID_SCALES As Short = 2004
    Public Const M_GRAPH_TITLES As Short = 2005
    Public Const M_GRAPH_3D_VIEWING_ANGLE As Short = 2006
    Public Const M_GRAPH_SAVE_AS_TEMPLATE As Short = 2008

    '----------------------------------------------------------------------------
    ' MapBasic menu
    '----------------------------------------------------------------------------
    Public Const M_MAPBASIC_CLEAR As Short = 1101
    Public Const M_MAPBASIC_SAVECONTENTS As Short = 1102

    '----------------------------------------------------------------------------
    ' Redistrict menu
    '----------------------------------------------------------------------------
    Public Const M_REDISTRICT_ASSIGN As Short = 705
    Public Const M_REDISTRICT_TARGET As Short = 706
    Public Const M_REDISTRICT_ADD As Short = 707
    Public Const M_REDISTRICT_DELETE As Short = 708
    Public Const M_REDISTRICT_OPTIONS As Short = 709

    '----------------------------------------------------------------------------
    ' Legend menu
    '----------------------------------------------------------------------------
    Public Const M_LEGEND_PROPERTIES As Short = 1901
    Public Const M_LEGEND_REFRESH As Short = 1902
    Public Const M_LEGEND_ADD_FRAMES As Short = 1903
    Public Const M_LEGEND_DELETE As Short = 1904

    '----------------------------------------------------------------------------
    ' 3DMap menu
    '----------------------------------------------------------------------------
    Public Const M_3DMAP_VIEW_ENTIRE_GRID As Short = 2101
    Public Const M_3DMAP_PROPERTIES As Short = 2102
    Public Const M_3DMAP_REFRESH_GRID_TEXTURE As Short = 2103
    Public Const M_3DMAP_WIREFRAME As Short = 2104
    Public Const M_3DMAP_CLONE_VIEW As Short = 2105
    Public Const M_3DMAP_PREVIOUS_VIEW As Short = 2106
    Public Const M_3DMAP_VIEWPOINT_CONTROL As Short = 2107

    '----------------------------------------------------------------------------
    ' Main Buttonpad
    '----------------------------------------------------------------------------
    Public Const M_TOOLS_SELECTOR As Short = 1701
    Public Const M_TOOLS_SEARCH_RECT As Short = 1722
    Public Const M_TOOLS_SEARCH_RADIUS As Short = 1703
    Public Const M_TOOLS_SEARCH_BOUNDARY As Short = 1704
    Public Const M_TOOLS_EXPAND As Short = 1705
    Public Const M_TOOLS_SHRINK As Short = 1706
    Public Const M_TOOLS_RECENTER As Short = 1702
    Public Const M_TOOLS_PNT_QUERY As Short = 1707
    Public Const M_TOOLS_HOTLINK As Short = 1736
    Public Const M_TOOLS_LABELER As Short = 1708
    Public Const M_TOOLS_DRAGWINDOW As Short = 1734
    Public Const M_TOOLS_RULER As Short = 1710

    '----------------------------------------------------------------------------
    ' Drawing Buttonpad
    '----------------------------------------------------------------------------
    Public Const M_TOOLS_POINT As Short = 1711
    Public Const M_TOOLS_LINE As Short = 1712
    Public Const M_TOOLS_POLYLINE As Short = 1713
    Public Const M_TOOLS_ARC As Short = 1716
    Public Const M_TOOLS_POLYGON As Short = 1714
    Public Const M_TOOLS_ELLIPSE As Short = 1715
    Public Const M_TOOLS_RECTANGLE As Short = 1717
    Public Const M_TOOLS_ROUNDEDRECT As Short = 1718
    Public Const M_TOOLS_TEXT As Short = 1709
    Public Const M_TOOLS_FRAME As Short = 1719
    Public Const M_TOOLS_ADD_NODE As Short = 1723

    '----------------------------------------------------------------------------
    ' DBMS Buttonpad
    '  -- most DBMS buttons defined under M_TABLE_{...} except for this one:
    '----------------------------------------------------------------------------
    Public Const M_DBMS_OPEN_ODBC As Short = 116

    '----------------------------------------------------------------------------
    ' Menu and ButtonPad items that do not appear in the standard menus
    '----------------------------------------------------------------------------
    Public Const M_TOOLS_MAPBASIC As Short = 1720
    Public Const M_TOOLS_SEARCH_POLYGON As Short = 1733

    '----------------------------------------------------------------------------
    ' Codes used to position Adornments relative to mapper
    '----------------------------------------------------------------------------

    Public Const ADORNMENT_INFO_MAP_POS_TL As Short = 0
    Public Const ADORNMENT_INFO_MAP_POS_TC As Short = 1
    Public Const ADORNMENT_INFO_MAP_POS_TR As Short = 2
    Public Const ADORNMENT_INFO_MAP_POS_CL As Short = 3
    Public Const ADORNMENT_INFO_MAP_POS_CC As Short = 4
    Public Const ADORNMENT_INFO_MAP_POS_CR As Short = 5
    Public Const ADORNMENT_INFO_MAP_POS_BL As Short = 6
    Public Const ADORNMENT_INFO_MAP_POS_BC As Short = 7
    Public Const ADORNMENT_INFO_MAP_POS_BR As Short = 8
    Public Const SCALEBAR_INFO_BARTYPE_CHECKEDBAR_CHECKEDBAR As Short = 0
    Public Const SCALEBAR_INFO_BARTYPE_CHECKEDBAR_SOLIDBAR As Short = 1
    Public Const SCALEBAR_INFO_BARTYPE_CHECKEDBAR_LINEBAR As Short = 2
    Public Const SCALEBAR_INFO_BARTYPE_CHECKEDBAR_TICKBAR As Short = 3

    '----------------------------------------------------------------------------
    ' Coordinate system datum id's.  These match the id's from mapinfow.prj.
    '----------------------------------------------------------------------------
    Public Const DATUMID_NAD27 As Short = 62
    Public Const DATUMID_NAD83 As Short = 74
    Public Const DATUMID_WGS84 As Short = 104

    '============================================================================
    ' end of MENU.DEF
    '============================================================================

End Class
