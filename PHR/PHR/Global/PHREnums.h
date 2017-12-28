//
//  PHREnums.h
//  PHR
//
//  Created by Luong Le Hoang on 10/3/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

typedef NS_ENUM(NSInteger, StandardHomeType) {
    StandardHomeTypeBodyMeasurement = 0,
    StandardHomeTypeFood = 1,
    StandardHomeTypeMedicine = 2,
    StandardHomeTypeCourseNote= 3,
    StandardHomeTypeHealthRecord= 4,
    StandardHomeTypeTemprature= 5,
    StandardHomeTypeLifeStyle= 6, // Sleep
    StandardHomeTypeFitness = 7,
    StandardHomeTypeMovieTalk = 8
};

typedef NS_ENUM(NSInteger, DiagnosisFieldType) {
    DiagnosisFieldTypeText,
    DiagnosisFieldTypeComboBox,
};

typedef NS_ENUM(NSInteger, PHRGroupType) {
    PHRGroupTypeStandard,
    PHRGroupTypeBaby,
    PHRGroupTypeDiseaes,
    PHRGroupTypeLifeStyleNote,
    PHRGroupTypeTemperature,
    PHRGroupTypeFood,
    PHRGroupTypeGrowth
};

typedef NS_ENUM(NSInteger, SCREEN_MENU){
    ENUM_MENU_DISPLAY_SETTING,
    ENUM_MENU_HELP_CENTER,
    ENUM_MENU_REPORT_A_PROBLEM,
    ENUM_MENU_ABOUT,
    ENUM_MENU_TERM_POLICIES,
    ENUM_MENU_CHANGE_PASSWORD,
    ENUM_MENU_LOGOUT
};

typedef NS_ENUM(NSInteger, PHRBabyGroupType) {
    PHRBabyGroupTypeMedicine = 8,
    PHRBabyGroupTypeVaccine = 9,
    PHRBabyGroupTypeFood = 10,
    PHRBabyGroupTypeGrowth = 11,
    PHRBabyGroupTypeMilk = 12,
    PHRBabyGroupTypeDiaper = 13,
    PHRBabyGroupTypeSleep = 14
};

typedef NS_ENUM(NSInteger, PHRGroupTypeMilk) {
    PHRGroupTypeMotherMilk = 0,
    PHRGroupTypeBottleMilk = 1
};

// ----------------- Standard --------------------
// Medicine
typedef NS_ENUM(NSInteger, PHRMedicineMethod) {
    PHRMedicineMethodDrink,
    PHRMedicineMethodInject,
    PHRMedicineMethodSuppository,
    PHRMedicineMethodInfusion
};

typedef NS_ENUM(NSInteger, PHRMedicineViewType) {
    PHRMedicineTodayDrug,
    PHRMedicinePresciprionList
};

typedef NS_ENUM(NSInteger, PHRMedicineAddType) {
    PHRMedicineAddRemider,
    PHRMedicineAddNewDrug
};


typedef NS_ENUM(NSInteger, PHRMedicineUnit) {
    PHRMedicineUnitCapsule,
    PHRMedicineUnitPill,
    PHRMedicineUnitAmpoule
};

typedef NS_ENUM(NSInteger, PHRTABLEVIEWSTYLE) {
    PHR_TABLEVIEW_TODAY = 0,
    PHR_TABLEVIEW_YESTERDAY ,
    PHR_TABLEVIEW_TWODAYSAGO
};

typedef NS_ENUM(NSInteger, PHR_ICON_MEDICINE) {
    PHR_ICON_MEDICINE_1 = 0,
    PHR_ICON_MEDICINE_2,
    PHR_ICON_MEDICINE_3,
    PHR_ICON_MEDICINE_4,
    PHR_ICON_MEDICINE_5,
    PHR_ICON_MEDICINE_6,
    PHR_ICON_MEDICINE_7
};

// -------- Baby ---------
typedef NS_ENUM(NSInteger, PHRBabyChartType) {
    PHRBabyChartTypeGrowth,
    PHRBabyChartTypeMotherMilk,
    PHRBabyChartTypeBottleMilk,
    PHRBabyChartTypeDiaper,
    PHRBabyChartTypeFood
};

// -------- Standard ---------
typedef NS_ENUM(NSInteger, PHRStandardChartType) {
    PHRStandardChartTypeHealth,
    PHRStandardChartTypeFood,
    PHRStandardChartTypeLifeStyle,
    PHRStandardChartTypeTemperature
};

typedef NS_ENUM(NSInteger, ButtonTimeIntervalClick) {
    ButtonTimeIntervalDaily = 0,
    ButtonTimeIntervalWeekly = 1,
    ButtonTimeIntervalMonthly = 2,
    ButtonTimeIntervalYear = 3,
};

// -------- Fitness ---------
typedef NS_ENUM(NSInteger, PHRFitnessAddType) {
    PHRFitnessAddTypeStepCount = 0,
    PHRFitnessAddTypeWalkingRunDistance = 1
};

typedef NS_ENUM(NSInteger, ChartContentType) {
    ChartContentTypeHeight = 0,
    ChartContentTypeWeight = 1,
    ChartContentTypeBodyFat = 2,
    ChartContentTypeBMI = 3
};

typedef NS_ENUM(NSInteger, TwoBarSelectedIndex) {
    TwoBarSelectedIndexSummary,
    TwoBarSelectedIndexList
};

typedef NS_ENUM(NSInteger, MDTabBarTagType) {
    MDTabBarTagTypeDefault,
    MDTabBarTagTypeFourButton,
    MDTabBarTagTypeFourButtonNoBorder
};

typedef NS_ENUM(NSInteger, PHRTemperatureChartType) {
    PHRChartTemperature = 0,
    PHRChartBloodPressure = 1,
    PHRChartHeartRate = 2,
    PHRChartPrespiratory = 3,
    PHRChartBloodPressureHigh = 4
    
};

// -------- Food ---------
typedef NS_ENUM(NSInteger, ChartFoodType) {
    ChartFoodTypeCalories = 0,
    ChartFoodTypeCarbohydrates = 1,
    ChartFoodTypeTotalFat = 2
};

// -------- Food ---------
typedef NS_ENUM(NSInteger, ChartFitnessType) {
    ChartFitnessTypeSteps = 0,
    ChartFitnessTypeWalkRun = 1
};

// -------- Baby Milk --------
typedef NS_ENUM(NSInteger, ChartBabyMilk) {
    ChartBabyMilkTypeMother = 0,
    ChartBabyMilkTypeBottle = 1
};

typedef NS_ENUM(NSInteger, BodyMeasurementType) {
    BodyMeasurementTypeHeight = 0,
    BodyMeasurementTypeWeight = 1,
    BodyMeasurementTypeBodyFat = 2,
    BodyMeasurementTypeBMI = 3
};

typedef NS_ENUM(NSInteger, FoodType) {
    FoodTypeCalories = 0,
    FoodTypeCarbohydrates = 1,
    FoodTypeTotalFat = 2
};

typedef NS_ENUM(NSInteger, BabyGrowthType) {
    BabyGrowthHeight = 0,
    BabyGrowthWeight = 1
};

typedef NS_ENUM(NSInteger, ChartType) {
    ChartTypeDefault = 0,
    ChartHeartRate = 1,
    ChartTypeBloodPressure = 2
};

typedef NS_ENUM(NSUInteger, VideoChatViewTag)
{
    VIDEO_CHAT_TAG_ID = 1000,
    VIDEO_CHAT_TAG_WEBRTC_ACTION,
    VIDEO_CHAT_TAG_REMOTE_VIDEO,
    VIDEO_CHAT_TAG_LOCAL_VIDEO,
};

typedef NS_ENUM(NSInteger, MovieTalkButtonClickedIndex) {
    MOVIE_TALK_BUTTON_CAMERA = 0,
    MOVIE_TALK_BUTTON_MICROPHONE,
    MOVIE_TALK_BUTTON_END_CALL
};

typedef NS_ENUM(NSInteger, EXAMINATION_STATUS) {
    UPCOMING = 0,
    EXPIRED,
    COMPLETED
};


typedef NS_ENUM(NSInteger, MediaState) {
  MediaStateNewPlay = 0,
  MediaStateContinous = 1,
  MediaStatePause = 2,
  MediaStateFinish = 3,
  MediaStateNone = 4
};
