//
//  AppSettings.h
//  Method
//
//  Created by NextopHN on 3/23/15.cr
//  Copyright (c) 2015 Nextop. All rights reserved.
//
#import <UIKit/UIKit.h>
#import "AppDelegate.h"

#ifndef PHR_AppSettings_h
#define PHR_AppSettings_h

#define PHRAppDelegate                  ((AppDelegate *)[[UIApplication sharedApplication] delegate])
#define PHRAppStatus                    (((AppDelegate *)[[UIApplication sharedApplication] delegate]).appStatus)

//// -------------------- Server info ------------------------------------------
//#define ENVINRONMENT 2
//    
//// Define Env
//#if ENVINRONMENT == 0 // DEV
//static NSString * const PHRAPIBaseURLString = @"http://10.1.20.2:8080/";
//static NSString * const PHRAPIBaseURLUpload = @"http://10.1.20.2:8081/";
//static NSString * const PHRAPIBaseURLDownload = @"http://117.6.172.189:8010/download";
//static NSString * const PHRAPIBaseURLEMA = @"http://10.1.20.215:9888/";
//
//#elif ENVINRONMENT == 1 // UAT Internal
//static NSString * const PHRAPIBaseURLString = @"http://10.2.9.14:8081/"; // http://117.6.172.190:8082/ || upload http://10.20.1.2:8081/download/fileName
//static NSString * const PHRAPIBaseURLUpload = @"http://10.2.9.14:8082/";
//static NSString * const PHRAPIBaseURLDownload = @"http://117.6.172.189:8010/download";
//static NSString * const PHRAPIBaseURLEMA = @"http://10.2.9.26:9888/";
//
//#elif ENVINRONMENT == 2 // UAT Public
//static NSString * const PHRAPIBaseURLString = @"http://117.6.172.190:8081/";
//static NSString * const PHRAPIBaseURLUpload = @"http://117.6.172.190:8082/";
//static NSString * const PHRAPIBaseURLDownload = @"http://117.6.172.189:8010/download";
//static NSString * const PHRAPIBaseURLEMA = @"http://10.2.9.26:9888/";
//
//// Define Env
//#elif ENVINRONMENT == 3 // DEV2
//static NSString * const PHRAPIBaseURLString = @"http://10.1.20.215:8081/";
//static NSString * const PHRAPIBaseURLUpload = @"http://10.1.20.215:8081/";
//static NSString * const PHRAPIBaseURLDownload = @"http://117.6.172.189:8010/download";
//static NSString * const PHRAPIBaseURLEMA = @"http://10.1.20.215:9888/";
//
//#elif ENVINRONMENT == 4 // PRO
//static NSString * const PHRAPIBaseURLString = @"http://phrapi.karte.clinic:8081/";
//static NSString * const PHRAPIBaseURLUpload = @"http://10.1.20.215:8081/";
//static NSString * const PHRAPIBaseURLDownload = @"http://42.124.124.133:8010/download";
//static NSString * const PHRAPIBaseURLEMA = @"http://emrapi.karte.clinic:9888/";
//
//#endif

// ---------------------------------------------------------------------------

#pragma mark - Sync interval time define
static int const INTERVAL_TIME_SYNC_SERVER = 90;
static int const INTERVAL_TIME_SAVED_BLUETOOTH = 30;



#define PHR_URL_HELP_CENTRE                 @"https://www.karte.clinic/guidelines"
#define PHR_URL_TERM_POLICY                 @"https://www.karte.clinic/privacy-policy"

static NSString * FakeEmail =  @""; // @"luong.le.hoang@nextop.asia";
static NSString * FakePassword = @""; // @"123456789";

static int const PHR_FILE_UPLOAD_MAX = 3;

#pragma mark - APP INFO
// APP INFO
#define APP_NAME    kLocalizedString(kPersonalHealthRecord)

// Date format
static NSString * const PHR_SERVER_DATE_TIME_FORMAT_MMMM                    = @"MMMM dd, yyyy";
static NSString * const PHR_SERVER_DATE_TIME_FORMAT                         = @"yyyy-MM-dd'T'HH:mm:ss'Z'";

static NSString * const PHR_SERVER_DATE_SHORT_FORMAT                        = @"dd/MM/yyyy";

static NSString * const PHR_BIRTHDAY_SERVER_FORMAT                          = @"yyyy/MM/dd";

static NSString * const FACEBOOK_BIRTHDAY_TIME_FORMAT_MONTH_DAY_YEAR        = @"yyyy/MM/dd";
static NSString * const FACEBOOK_BIRTHDAY_TIME_FORMAT_MONTH_DAY             = @"MM/dd";
static NSString * const FACEBOOK_BIRTHDAY_TIME_FORMAT_YEAR                  = @"yyyy";

static NSString * const PHR_CLIENT_TIME_FORMAT_FULL                         = @"hh:mm a yyyy/MM/dd";

static NSString * const PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE            = @"MMMM dd, yyyy - hh:mm a";
static NSString * const PHR_TIME_FORMAT_YEAR_MONTH_DAY                      = @"yyyy/MM/dd";
static NSString * const PHR_AUDIO_PLAY_FORMAT                               = @"dd/MM/yyyy hh:mm";
#define PHR_TIME_REOPEN_APP             259200

// COLOR DEFINE
#define PHR_COLOR_CYAN                  RGBCOLOR(54., 199., 209.)
#define PHR_COLOR_LIGHT_BLUE            RGBCOLOR(19., 202., 255.)
#define PHR_COLOR_PINK                  RGBCOLOR(244., 136., 134.)
#define PHR_COLOR_ORANGE                RGBCOLOR(255., 96., 0.)
#define PHR_COLOR_GREEN                 RGBCOLOR(104., 229., 55.)
#define PHR_COLOR_YELLOW                RGBCOLOR(241., 194., 51.)
#define PHR_COLOR_PURPLE                RGBCOLOR(182., 126., 241.)
#define PHR_COLOR_LIGHT_GREEN           RGBCOLOR(58., 186., 124.)
#define PHR_COLOR_VIOLET                RGBCOLOR(133., 114., 247.)
#define PHR_COLOR_DARK_ORANGE           RGBCOLOR(213., 116., 51.)
#define PHR_COLOR_LIGHT_SOIL            RGBCOLOR(224., 228., 204.)
#define PHR_COLOR_GRAY                  RGBCOLOR(137.0, 137.0, 137.0)
#define PHR_COLOR_DATE_TIME             RGBCOLOR(72.0, 72.0, 72.0)
#define PHR_COLOR_LINE_GRAY             RGBACOLOR(160.0, 160.0, 160.0, 0.2)
#define PHR_COLOR_TEXT_GRAY             RGBCOLOR(140.0, 140.0, 140.0)
#define PHR_COLOR_TEXT_MEDICINES        RGBCOLOR(143.0, 143.0, 143.0)
#define PHR_COLOR_BG_MEDICINES          RGBCOLOR(250.0, 247.0, 243.0)
#define PHR_COLOR_WHITE                 RGBCOLOR(255.0, 254.0, 254.0)
#define PHR_COLOR_TEXT_MENU             RGBCOLOR(106.0, 106.0, 106.0)
#define PHR_COLOR_SKY_BLUE              RGBCOLOR(27.0, 163.0, 220.0)
#define PHR_COLOR_LIGHT_PINK            RGBCOLOR(243.0, 244.0, 244.0)
#define PHR_COLOR_TEXT_DRAK_GRAY        RGBCOLOR(50.0, 50.0, 50.0)
#define PHR_COLOR_HEADER_TABLE_VIEW     RGBCOLOR(242.0, 242.0, 242.0)
#define PHR_COLOR_MOVIE_TALK_BLUE       RGBCOLOR(9.0, 133.0, 237.0)

// use for 4 STAGE BMI
#define PHR_COLOR_BMI_UNDERWEIGHT       RGBCOLOR(0.0, 200.0, 255.0)
#define PHR_COLOR_BMI_NORMAL            RGBCOLOR(0.0, 255.0, 0.0)
#define PHR_COLOR_BMI_OVERWEIGHT        RGBCOLOR(255.0, 255.0, 0.0)
#define PHR_COLOR_BMI_OBESITY           RGBCOLOR(255, 128.0, 0.0)
#define PHR_COLOR_BMI_EXTREMEOBESITY    RGBCOLOR(255, 0.0, 0.0)

//Display setting
#define PHR_COLOR_BACKGROUND_CHOOSE         RGBCOLOR(247.0, 128.0, 1.0)

// SLIDE MENU
#define PHR_COLOR_SELECTED_SELL             RGBCOLOR(1., 195., 207.)

//COLOR TEMPERATURE SCREEN
#define PHR_COLOR_GRAY_LIGHT_TEMPERATURE    RGBCOLOR(157., 157.,157.)
#define PHR_COLOR_GRAY_DARK_TEMPERATURE     RGBCOLOR(77., 77.,77.)
#define PHR_COLOR_ORANGE_TEMPERATURE        RGBCOLOR(255., 127.,52.)

#pragma mark - VIEWS INFO PLACEHOLDER TEXTFIELD

//Size for text
#define PHR_SIZE_TEXT_TWENTY             12
#define PHR_SIZE_TEXT_FORTY              14

#define MENU_DISPLAY_SETTING            0
#define MENU_CHANGE_PASSWORD            1
#define MENU_SYNCHRONIZE_HEATHKIT       2
#define MENU_BLUETOOTH                  3
#define MENU_HELP_CENTER                4
#define MENU_TERM_POLICIES              5
#define MENU_ABOUT                      6
#define MENU_LOGOUT                     7

#define ChangeTitleAccLinked                    @"__ChangeTitleAccLinked__"
#define SelectedPropertyInStandard              @"__SelectedPropertyInStandard__"
#define PHRNotificationAutoSignIn               @"__PHRNotificationAutoSignIn__"
#define PHRNotificationShowStandard             @"__PHRNotificationShowStandard__"
#define PHRNotificationAddNewData               @"__PHRNotificationAddNewData__"
#define PHRNotificationEditData                 @"__PHRNotificationEditData__"
#define PHRNotificationRemoveData                 @"__PHRNotificationRemoveData__"
#define PHRNotificationRequestAuthorization     @"__PHRNotificationRequestAuthorization__"


#define PHR_STR_NULL                    @""
#define PHRAPIBasePathUpload            @"api/profiles/%@/upload"
#define PHRAPIBasePathDownload          @"download/"
#define PHRJNKeyChainEmail              @"email"
#define PHRJNKeyChainPass               @"password"
#define PHRJNKeyChainFacebookAccessToken @"facebookAccesstoken"
#define PHRJNKeyChainAllowSynchronizeHealthKitRead @"synchronizeHealthKitRead"
#define PHRJNKeyChainAllowSynchronizeHealthKitWrite @"synchronizeHealthKitWrite"
#define PHRJNKeyChainAllowSynchronizeHealthKitBy3G @"synchronizeHealthKitBy3G"
#define PHR_SIZE_IMG                    15.0
#define PHR_DATE_PM                     @"PM"
#define PHR_DATE_AM                     @"AM"
#define PHR_STR_DETACHMENT              @";"
#define BG_Baby_Medicine                @"BG_Children"
#define BG_Standard_Medicine            @"standard_bg"
#define PHR_ICON_UPLOAD_FILE            @"Icon_UploadFile"
#define PHR_ICON_DELETE_FILE            @"Icon_Delete"
#define PHR_IMG_NOTE_MORNING            @"Timeline_Note_Morning"
#define PHR_IMG_NOTE_AFTERNOON          @"Timeline_Note_Afternoon"
#define PHR_IMG_NOTE_NIGHT              @"Timeline_Note_Night"
#define PHR_DATETIME_LOCATE             @"en_US_POSIX"

#define PHR_ICON_MORNING                @"icon_morning_white"
#define PHR_ICON_AFTERNOON              @"icon_afternoon_white"
#define PHR_ICON_NIGHT                  @"icon_night_white"

#define PHR_ICON_MORNING_DARK           @"icon_morning_dark"
#define PHR_ICON_AFTERNOON_DARK         @"icon_afternoon_dark"
#define PHR_ICON_NIGHT_DARK             @"icon_night_dark"

#define PHR_TYPE_IDENTIFIER             @"type"
#define PHR_SLIDE_SPACE_BETWEEN_LINE          15
#define PHR_HEADER_FONT_SIZE                  18.0
#define PHR_SLIDE_LINE_WIDTH                  1
#define PHR_TABLE_VIEW_DELETE_BUTTON_HEIGHT       50
#define PHR_TABLE_VIEW_ITEM_HEIGHT                50


//Fitness Color
#define PHR_COLOR_FITNESS_TABBAR_DURATION_SELECTED   RGBCOLOR(25.0, 161.0, 283.0)
#define PHR_COLOR_FITNESS_NAV_RIGHT RGBACOLOR(255.0, 255.0, 0.0,0.8)
#define PHR_COLOR_HEADER_BACKGROUND_ORANGE    RGBCOLOR(255.0, 240.0, 228.0)
#define PHR_COLOR_TEXT_ORANGE_BOLD    RGBCOLOR(255.0, 108.0, 0.0)
#define PHR_COLOR_TEXT_BLACK    RGBCOLOR(88.0, 88.0, 88.0)
#define PHR_COLOR_NAV_LEFT    RGBACOLOR(66.0, 42.0, 40.0, 0.8)
#define PHR_COLOR_NAV_RIGHT    RGBACOLOR(63.0, 69.0, 38.0, 0.8)
#define PHR_COLOR_TABBAR_DURATION_UNSELECTED    RGBCOLOR(95.0, 93.0, 116.0)
#define PHR_COLOR_BODY_TABBAR_DURATION_SELECTED    RGBCOLOR(25.0, 161.0, 283.0)
#define PHR_COLOR_BODY_MEASUREMENT_TABBAR_TYPE RGBACOLOR(119.0, 76.0, 88.0, 0.8)

//Food
#define PHR_COLOR_FOOD_TABBAR_HEADER_BACKGROUND RGBCOLOR(232.0, 245.0, 253.0)
#define PHR_COLOR_FOOD_NAV_LEFT    RGBACOLOR(30.0, 47.0, 102.0, 0.8)
#define PHR_COLOR_FOOD_NAV_RIGHT    RGBACOLOR(18.0, 65.0, 105.0, 0.8)
#define PHR_COLOR_FOOD_TABBAR_TYPE RGBACOLOR(91.0, 82.0, 132.0, 0.8)

//FITNESS

#define PHR_COLOR_BODY_MEASUREMENT_NAV_LEFT RGBACOLOR(238.0, 159.0, 48.0,0.5)

//Vitals

#define PHR_COLOR_VITALS_NAV_LEFT RGBACOLOR(45.0,182.0, 199.0, 0.8)
#define PHR_COLOR_VITALS_TABBAR_TYPE RGBACOLOR(98.0, 71.0, 128.0, 0.5)

//Body measurement
#define PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR RGBCOLOR(238.0, 77.0, 48.0)
#define PHR_COLOR_BODY_MEASUREMENT_LIGHT_COLOR RGBCOLOR(252.0, 232.0, 228.0)
#define PHR_COLOR_BODY_MEASUREMENT_LIGHT_ALPHA RGBACOLOR(238.0, 159.0, 48.0, 0.4)
#define PHR_COLOR_BODY_MEASUREMENT_OVERLAY RGBACOLOR(72.0, 23.0, 14.0, 0.7)

//Food
#define PHR_COLOR_FOOD_MAIN_COLOR RGBCOLOR(25.0, 161.0, 238.0)
#define PHR_COLOR_FOOD_LIGHT_COLOR RGBCOLOR(222.0, 243.0, 255.0)
#define PHR_COLOR_FOOD_LIGHT_ALPHA RGBACOLOR(25.0, 161.0, 238.0, 0.4)
#define PHR_COLOR_FOOD_OVERLAY RGBACOLOR(8.0, 49.0, 72.0, 0.7)

//Fitness
#define PHR_COLOR_FITNESS_MAIN_COLOR RGBCOLOR(255.0, 186.0, 20.0)
#define PHR_COLOR_FITNESS_LIGHT_COLOR RGBCOLOR(250.0, 243.0, 225.0)
#define PHR_COLOR_FITNESS_LIGHT_ALPHA RGBACOLOR(255.0, 186.0, 20.0, 0.4)
#define PHR_COLOR_FITNESS_OVERLAY RGBACOLOR(77.0, 56.0, 6.0, 0.7)

//Life Style Note
#define PHR_COLOR_LIFE_STYLE_MAIN_COLOR RGBCOLOR(120.0, 185.0, 30.0)
#define PHR_COLOR_LIFE_STYLE_LIGHT_COLOR RGBCOLOR(240.0, 248.0, 232.0)
#define PHR_COLOR_LIFE_STYLE_LIGHT_ALPHA RGBACOLOR(100.0, 185.0, 30.0, 0.4)
#define PHR_COLOR_LIFE_STYLE_OVERLAY RGBACOLOR(30.0, 56.0, 9.0, 0.7)

//Vitals
#define PHR_COLOR_VITALS_MAIN_COLOR RGBCOLOR(144.0, 183.0, 232.0)
#define PHR_COLOR_VITALS_LIGHT_COLOR RGBCOLOR(238.0, 243.0, 250.0)
#define PHR_COLOR_VITALS_LIGHT_ALPHA RGBACOLOR(144.0, 183.0, 232.0, 0.4)
#define PHR_COLOR_VITALS_OVERLAY RGBACOLOR(106.0, 115.0, 125.0, 0.7)

//Health Record
#define PHR_COLOR_HEALTH_RECORD_MAIN_COLOR RGBCOLOR(138.0, 221.0, 212.0)
#define PHR_COLOR_HEALTH_RECORD_LIGHT_COLOR RGBCOLOR(232.0, 246.0, 245.0)
#define PHR_COLOR_HEALTH_RECORD_LIGHT_ALPHA RGBACOLOR(138.0, 221.0, 232.0, 0.4)
#define PHR_COLOR_HEALTH_RECORD_OVERLAY RGBACOLOR(42.0, 67.0, 70.0, 0.7)

//Medicine
#define PHR_COLOR_MEDICINE_MAIN_COLOR RGBCOLOR(255.0, 161.0, 149.0)
#define PHR_COLOR_MEDICINE_LIGHT_COLOR RGBCOLOR(249.0, 233.0, 231.0)
#define PHR_COLOR_MEDICINE_LIGHT_ALPHA RGBACOLOR(255.0, 161.0, 49.0, 0.4)
#define PHR_COLOR_MEDICINE_OVERLAY RGBACOLOR(77.0, 49.0, 45.0, 0.5)

//Dashboard
#define PHR_COLOR_DASHBOARD_BODY_MEASUREMENT        RGBCOLOR(238., 77., 48.)
#define PHR_COLOR_DASHBOARD_FOOD                    RGBCOLOR(25., 161., 238.)
#define PHR_COLOR_DASHBOARD_FITNESS                 RGBCOLOR(252., 235., 43.)
#define PHR_COLOR_DASHBOARD_LIFE_STYLE                RGBCOLOR(124., 235., 38.)
#define PHR_COLOR_DASHBOARD_VITALS                 RGBCOLOR(144., 183., 232.)
#define PHR_COLOR_DASHBOARD_HEALTH_RECORD                RGBCOLOR(123., 197., 189.)
#define PHR_COLOR_DASHBOARD_MEDICINE                RGBCOLOR(248., 157., 145.)

// Baby milk
#define PHR_BABY_MILK_TYPE   @"BabyMilkType"
#define PHR_BABY_FOOD_TYPE   @"BabyFoodType"
#define PHR_BABY_DIAPER_TYPE   @"BabyDiaperType"
#define PHR_BABY_MILK_MOTHER @"MotherMilk"
#define PHR_BABY_MILK_BOTTLE @"BottleMilk"
#define PHR_BABY_MILK_TIME   @"BabyTime"
#define PHR_BABY_MILK_VOLUME @"BabyVolume"
#define PHR_BABY_HK_QUANTITY_HEIGHT @"HKQuantityTypeIdentifierHeightBaby"
#define PHR_BABY_HK_QUANTITY_BODY_MASS @"HKQuantityTypeIdentifierBodyMassBaby"

//Baby Milk
#define PHR_COLOR_BABY_MILK_MAIN_COLOR RGBCOLOR(0.0, 197.0, 255.0)
#define PHR_COLOR_BABY_MILK_LIGHT_COLOR RGBCOLOR(231.0, 246.0, 250.0)
#define PHR_COLOR_BABY_MILK_LIGHT_ALPHA RGBACOLOR(0.0, 197.0, 255.0, 0.4)
#define PHR_COLOR_BABY_MILK_OVERLAY RGBACOLOR(76.0, 117.0, 130.0, 0.7)

//Baby Medicine
#define PHR_COLOR_BABY_MEDICINE_MAIN_COLOR RGBCOLOR(255.0, 160.0, 148.0)
#define PHR_COLOR_BABY_MEDICINE_LIGHT_COLOR RGBCOLOR(252.0, 240.0, 238.0)
#define PHR_COLOR_BABY_MEDICINE_LIGHT_ALPHA RGBACOLOR(255.0, 160.0, 148.0, 0.4)
#define PHR_COLOR_BABY_MEDICINE_OVERLAY RGBACOLOR(130.0, 110.0, 108.0, 0.7)

//Baby Diaper
#define PHR_COLOR_BABY_DIAPER_MAIN_COLOR RGBCOLOR(255.0, 190.0, 0.0)
#define PHR_COLOR_BABY_DIAPER_LIGHT_COLOR RGBCOLOR(250.0, 245.0, 231.0)
#define PHR_COLOR_BABY_DIAPER_LIGHT_ALPHA RGBACOLOR(255.0, 190.0, 0.0, 0.4)
#define PHR_COLOR_BABY_DIAPER_OVERLAY RGBACOLOR(130.0, 116.0, 76.0, 0.7)

//Baby Food
#define PHR_COLOR_BABY_FOOD_MAIN_COLOR RGBCOLOR(247.0, 146.0, 30.0)
#define PHR_COLOR_BABY_FOOD_LIGHT_COLOR RGBCOLOR(251.0, 244.0, 235.0)
#define PHR_COLOR_BABY_FOOD_LIGHT_ALPHA RGBACOLOR(247.0, 146.0, 30.0, 0.4)
#define PHR_COLOR_BABY_FOOD_OVERLAY RGBACOLOR(129.0, 107.0, 82.0, 0.7)

//Baby Growth
#define PHR_COLOR_BABY_GROWTH_MAIN_COLOR RGBCOLOR(57.0, 181.0, 73.0)
#define PHR_COLOR_BABY_GROWTH_LIGHT_COLOR RGBCOLOR(243.0, 246.0, 243.0)
#define PHR_COLOR_BABY_GROWTH_LIGHT_ALPHA RGBACOLOR(57.0, 181.0, 73.0, 0.4)
#define PHR_COLOR_BABY_GROWTH_OVERLAY RGBACOLOR(88, 115.0, 91.0, 0.7)

//Baby Sleep
#define PHR_COLOR_BABY_SLEEP_MAIN_COLOR RGBCOLOR(206.0, 120.0, 255.0)
#define PHR_COLOR_BABY_SLEEP_LIGHT_COLOR RGBCOLOR(246.0, 239.0, 250.0)
#define PHR_COLOR_BABY_SLEEP_LIGHT_ALPHA RGBACOLOR(206.0, 120.0, 255.0, 0.4)
#define PHR_COLOR_BABY_SLEEP_OVERLAY RGBACOLOR(120, 101.0, 130.0, 0.7)

//MovieTalk
#define PHR_COLOR_MOVIE_TALK_NAV_LEFT RGBACOLOR(252.0, 142.0, 127.0, 0.3)
#define PHR_COLOR_MOVIE_TALK_NAV_RIGHT RGBACOLOR(246.0, 226.0, 174.0, 0.3)
#define PHR_COLOR_MOVIE_TALK_HEADER_LEFT RGBACOLOR(246.0, 226.0, 174.0, 0.2)
#define PHR_COLOR_MOVIE_TALK_HEADER_RIGHT RGBACOLOR(252.0, 142.0, 127.0, 0.2)

//Add remind
#define PHR_REMIND_END_DATE @"ENDDATE"
#endif
