//
//  METLocalizeKey.h
//  Method
//
//  Created by Nextop HN 2 on 3/26/15.
//  Copyright (c) 2015 Nextop. All rights reserved.
//

#import <Foundation/Foundation.h>

#ifndef PHRLocalizedKey
#define PHRLocalizedKey
// ------------------ HOME ---------------------
// Common
static NSString *const kBack        = @"Back";
static NSString *const kCancel      = @"Cancel";
static NSString *const kAgree       = @"Agree";
static NSString *const kClose       = @"Close";
static NSString *const kSave            = @"Save";
static NSString *const kDone = @"Done";
static NSString *const kSent = @"Sent";
static NSString *const kSubmit = @"Submit";
static NSString *const kRateFinish = @"Finish";
static NSString *const kOK          = @"OK";
static NSString *const kEdit = @"Edit";
static NSString *const kYes = @"Yes";
static NSString *const kNo = @"No";
static NSString *const kConfirm = @"Confirm";
static NSString *const kAdd             = @"Add";
static NSString *const kNote            = @"Note";
static NSString *const kDATETIME        = @"DATETIME";
static NSString *const kMorning     = @"Morning";
static NSString *const kNoon = @"Noon";
static NSString *const kAfternoon   = @"Afternoon";
static NSString *const kNight       = @"Night";
static NSString *const kAddSuccess  = @"Successful";
static NSString *const kUploadFile  = @" Upload File";
static NSString *const kTime        = @"Time";
static NSString *const kMilkType    = @"Milk Type";
static NSString *const kTitleUpload = @"EVIDENCE UPLOADED";
static NSString *const kStatus      = @"Status";
static NSString *const kTitlePreUp  = @"PRESCRIPTION UPLOADED";
static NSString *const kVolume      = @"Volume";
static NSString *const kChoose      = @"Choose";
static NSString *const KEY_Content  = @"content";
static NSString *const KEY_Medicine_List  = @"medicine_list";
static NSString *const KEY_Id       = @"id";
static NSString *const kTitleDailyAverage  = @"Daily Average:";
static NSString *const kTitleAverage  = @"Average:";
static NSString *const kChangeBackgroundImageSuccess = @"Change Background Image Successfully";
static NSString *const kAddNew              = @"Add New";
static NSString *const kByDay               = @"By DAY";
static NSString *const kByWeek              = @"By WEEK";
static NSString *const kByMonth             = @"By MONTH";
static NSString *const kByYear              = @"By YEAR";
static NSString *const kListAccount         = @"List Account";
static NSString *const kAddNewAccount       = @"Add New Account";
static NSString *const kTotal               = @"Total";
static NSString *const kMin                 = @"Min";
static NSString *const kMax                 = @"Max";
static NSString *const kPullToRefresh       = @"Pull to refresh";
static NSString *const kReleaseToRefresh    = @"Release to refresh";
static NSString *const kLoading             = @"Loading";
static NSString *const kLongTimeNoSee       = @"Long time no see";
static NSString *const kCancelled           = @"cancelled";
static NSString *const kChooseProfile       = @"Choose Profile Dialog";
static NSString *const kAlertSysHealthKit   = @"Alert syn from HealthKit";
static NSString *const kAlert               = @"Alert";
static NSString *const kAlertStart          = @"Alert Start";
static NSString *const kAlertFinish         = @"Alert Finish";

// Unit
static NSString *const kUnitInch = @"inch";
static NSString *const kUnitCm = @"cm";
static NSString *const kUnitPound = @"pound";
static NSString *const kUnitKg = @"kg";
static NSString *const kUnitPercent = @"%";
static NSString *const kUnitKcal = @"Kcal";
static NSString *const kMedicalRecord = @"MEDICAL RECORD";
static NSString *const kUnitKgM = @"kg/m^2";
static NSString *const kUnitG = @"g";
static NSString *const kUnitKm = @"Km";
static NSString *const kUnitCal = @"Cal";
static NSString *const kUnitMmHG = @"mmHg";
static NSString *const kUnitBpm = @"bpm";
static NSString *const kUnitBreathMin = @"breaths/min";

// Home - SignIn
static NSString *const kHealthCareRecorder = @"Health Care Recorder";
static NSString *const kHealthCare = @"Health Care";
static NSString *const kRecorder = @"Recorder";
static NSString *const konKCCK = @"on KCCK";
static NSString *const kSignInByFacebook = @"Sign in by Facebook";
static NSString *const kPersonal = @"Personal";
static NSString *const kHealth = @"Health";
static NSString *const kRecord = @"Record";
static NSString *const kPersonalHealthRecord = @"Personal Health Record";
static NSString *const kHealthCareOnKCCK = @"Health Care Recorder on KCCK";;
static NSString *const kAProductOfKarteClinic = @"A product of Karte.Clinic";
static NSString *const kSignIn = @"Sign in";
static NSString *const kPassword = @"Password";
static NSString *const kSignInMissEmail     = @"Email can not empty";
static NSString *const kSignInMissUserName  = @"Please enter username";
static NSString *const kSignInMissPassword  = @"Please enter password";
static NSString *const kOldPassword         = @"Old Password";
static NSString *const kNewPassword         = @"New Password";
static NSString *const kNewPasswordConfirm  = @"New Password (Confirm)";
static NSString *const kEnterTime           = @"Please enter time";
static NSString *const kInvalidEmail        = @"Email wrong format";
static NSString *const kLoginFail           = @"login.fail.notice";
static NSString *const kFacebookLoginFail   = @"facebook.login.fail.notice";
// Pre Login
static NSString *const kAgreement           = @"Agreement";
static NSString *const kGetStart            = @"Get Started";
static NSString *const kHaveAnAccount       = @"I have an PHR account";
// Forgot password
static NSString *const kForgotPassword = @"Forgot password";
static NSString *const kForgotPasswordDescription = @"Forgot password description";
static NSString *const kForgotPasswordSuccessMessage = @"Forgot password success message";
static NSString *const kResetPasswordDescription  = @"Reset password description";

// SignUp
static NSString *const kTitleRegister = @"Register";
static NSString *const kRegisterWithFacebook = @"Register with Facebook";
static NSString *const kRegister = @"Register Now";
static NSString *const kName = @"Name";
static NSString *const kNameKana = @"Name Kana";
static NSString *const kNickname = @"Nickname";
static NSString *const kFirstName = @"First Name";
static NSString *const kFirstNameKana = @"First Name Kana";
static NSString *const kLastName = @"Last Name";
static NSString *const kLastNameKana = @"Last Name Kana";
static NSString *const kGender = @"Gender";
static NSString *const kBirthday = @"Birthday";
static NSString *const kEmail = @"Email";
static NSString *const kEmailInvalid    = @"Email invalid";
static NSString *const kGenderInvalid    = @"Gender invalid";
static NSString *const kNameInvalid     = @"Name invalid";
static NSString *const kNameKanaInvalid = @"Namekana invalid";
static NSString *const kBirthdayInvalid = @"Birthday invalid";
static NSString *const kSignUpDescription = @"SignUp Description";
static NSString *const kSignUpSuccessMessage = @"Notice sign up %@ success";
static NSString *const kSignUpMale = @"Male";
static NSString *const kSignUpFemale = @"Female";
static NSString *const kRegisterNewAccount = @"Register new Account";
static NSString *const kOr = @"OR";

// Change password
static NSString *const kChangePassMissOldPassword = @"Please enter old password";
static NSString *const kChangePassMissNewPassword = @"Please enter new password";
static NSString *const kChangePassMissNewPasswordConfirm = @"Please enter new password confirm";
static NSString *const kChangePassDontMatchPassword = @"New password and New password confirm aren't match";
static NSString *const kChangePassSuccessMessage = @"Change password successful";

// ---------------- Setting -----------------
static NSString *const kSettingTitle = @"Setting";
static NSString *const kDisplaySettingTitle = @"Display Setting";
static NSString *const kHelpCenterTitle = @"Help Center";
static NSString *const kReportProblemTitle = @"Report a Problem";
static NSString *const kAboutTitle = @"About";
static NSString *const kTermPoliciesTitle = @"Term & Policies";
static NSString *const kChangePasswordTitle = @"Change Password";
static NSString *const kLogoutTitle = @"Log Out";

static NSString *const kAboutMessage = @"Message About";
static NSString *const kCompanyName = @"Company link";
static NSString *const kPolicyMessage = @"Message Policy";
static NSString *const kHelpCenterMessage = @"Message Help Center";

static NSString *const kStandardScreen = @"Standard Screen";
static NSString *const kBabyScreen     = @"Baby Screen";
static NSString *const kBoth           = @"Both";

static NSString *const kUploadImage    = @"Upload image";
//static NSString *const kNotAllowed     = @"Not Allowed";

static NSString *const kNotAllowed     = @"Not Allowed";
static NSString *const kBackToDashboard = @"BACK TO DASHBOARD";

// ----------------- Dashboard ---------------
// Common
static NSString *const kStandardTitle   = @"Standard";
static NSString *const kBabyTitle       = @"Baby";

static NSString *const kFamilyList      = @"Family List";
static NSString *const kBabyList        = @"Baby List";
static NSString *const kUnknowName      = @"Unknow Name";
static NSString *const kHoldProfile     = @"Hold Profile";
static NSString *const kHowToUpdate     = @"How To Update Profile";

// >>>>> Standard <<<<<<
// > Home <
static NSString *const kToday           = @"Today";
static NSString *const kYesterday       = @"Yesterday";
static NSString *const kDaySuffixST     = @"Day Suffix ST";
static NSString *const kDaySuffixND     = @"Day Suffix ND";
static NSString *const kDaySuffixRD     = @"Day Suffix RD";
static NSString *const kDaySuffixTH     = @"Day Suffix TH";
// Profile
static NSString *const kProfile = @"Profile";
static NSString *const kZipCode = @"Zip Code";
static NSString *const kPrefecture = @"Prefecture";
static NSString *const kCity = @"City";
static NSString *const kAddress = @"Address";
static NSString *const kOccupation = @"Occupation";
static NSString *const kRelationship = @"Relationship";
static NSString *const kLinkedClinicAccounts = @"Linked Clinic Accounts";
static NSString *const kHospital = @"Hospital";
static NSString *const kUserName = @"User Name";
static NSString *const kMaster = @"Master";
static NSString *const kPleaseEnterBirthday = @"Please enter birthday";
static NSString *const kPatientCode = @"Patient code";
static NSString *const kInputChildHeight = @"Please input child's height";
static NSString *const kInputChildWeight = @"Please input child's weight";

//Family List
static NSString *const kDeleteProfileSuccessfully = @"Delete profile successfully";

// Health
static NSString *const kTitleHealth         = @"Health";
static NSString *const kHealthBMIChart      = @"BMI Chart";
static NSString *const kHealthTimeLine      = @"Timeline";
static NSString *const kUnitBmi             = @"Health bmi";
static NSString *const kPHHeightUnit        = @"Height (cm)";
static NSString *const kPHWeightUnit        = @"Weight (kg)";
static NSString *const kPHHeight            = @"Height";
static NSString *const kPHWeight            = @"Weight";
static NSString *const kPHWaistline         = @"Waistline (cm)";
static NSString *const kPHChestSize         = @"Chest Size (cm)";
static NSString *const kPHLowBlood          = @"Low blood pressure (mmHg)";
static NSString *const kPHHighBlood         = @"High blood pressure (mmHg)";
static NSString *const kPHHighLowBlood      = @"High/Low blood pressure";
static NSString *const kPHPercentOfFat      = @"Percentage Of fat (%)";
static NSString *const kHeadSize            = @"Head Size (cm)";
static NSString *const kHealthMissDatetime  = @"Please enter datetime";
static NSString *const kHealthMissHeight    = @"Please enter height";
static NSString *const kHealthMissWeight    = @"Please enter weight";
static NSString *const kHealthMissWaistline = @"Please enter waistline";
static NSString *const kHealthMissChestSize = @"Please enter chest size";
static NSString *const kHealthMissLowBlood  = @"Please enter low blood press";
static NSString *const kHealthMissHighBlood = @"Please enter high blood press";
static NSString *const kHealthMissPercent   = @"Please enter percent of fat";
static NSString *const kHealthNumberInvalidHeightAndWeight = @"Please enter height and weight as a number";
static NSString *const kTitleParentNote     = @"Parent";
static NSString *const kTitleDoctorNote     = @"Doctor";
static NSString *const kBMIUnderWeight      = @"UnderWeight";
static NSString *const kNormal              = @"Normal";
static NSString *const kHypotension         = @"Hypotension";
static NSString *const kHypertensive        = @"Hypertensive";
static NSString *const kLow                 = @"Low";
static NSString *const kHigh                = @"High";
static NSString *const kVeryHigh            = @"Very High";
static NSString *const kBest                = @"Best";
static NSString *const kObesity             = @"Obesity";
static NSString *const kFever               = @"Fever";
static NSString *const kHyperthermia        = @"Hyperthermia";
static NSString *const kHypothermia         = @"Hypothermia";
static NSString *const kBMIOverWeight       = @"OverWeight";
static NSString *const kDaily               = @"Daily";
static NSString *const kWeekly              = @"Weekly";
static NSString *const kMonthly             = @"Monthly";
static NSString *const kYear                = @"Year";
static NSString *const kTotalFat            = @"TotalFat";
static NSString *const kCalories            = @"Calories";
static NSString *const kCarbohydrate        = @"Carbohydrate";
static NSString *const kHealthMissBMI       = @"Please enter bmi";
static NSString *const kAddCalories         = @"Add new Calories";
static NSString *const kAddCarbohydrate     = @"Add new Carbohydrate";
static NSString *const kAddTotalFat         = @"Add new Total Fat";
static NSString *const kDottedCalories      = @"᛫Calories";
static NSString *const kDottedCarbohydrate  = @"᛫Carbohydrate";
static NSString *const kDottedTotalFat      = @"᛫Total Fat";
static NSString *const kHighBloodPressure   = @"High blood pressure";
static NSString *const kLowBloodPressure    = @"Low blood pressure";

// Body Measurement
static NSString *const kTitleBodyMeasurement  = @"BodyMeasurement";
static NSString *const kSummaryData        = @"SummaryData";
static NSString *const kList                       = @"List";
static NSString *const kBodyFatPercentage        = @"BodyFatPercentage";
static NSString *const kBodyMassIndex  = @"BodyMassIndex";
static NSString *const kBMI  = @"BMI";
static NSString *const kHeightUppercase  = @"Height uppercase";
static NSString *const kWeightUppercase  = @"Weight uppercase";
static NSString *const kCMUppercase  = @"CM uppercase";
static NSString *const kKGUppercase  = @"KG uppercase";
static NSString *const kAddNewHeight = @"Add new Height";
static NSString *const kAddNewWeightAndFat = @"Add new Weight & Body Fat";
static NSString *const kAddNewBMI = @"Add new BMI";
static NSString *const kEnterWeightPercentFat = @"Please enter weight and percent fat";

// Food
static NSString *const kTitleFood          = @"Food";
static NSString *const kRateGood           = @"Good";
static NSString *const kRatingSatisfid     = @"RATING SATISFIED";
static NSString *const kTitleMealType      = @"Meal type";
static NSString *const kHealthMissKcal     = @"Please enter Kcal number";
static NSString *const kFoodMissFood       = @"Please enter food name";

// Medicine
static NSString *const kTitleMedicine               = @"Medicine";
static NSString *const kMedicineMethodDrink         = @"Method Drink";
static NSString *const kMedicineMethodInject        = @"Method Inject";
static NSString *const kMedicineMethodSuppository   = @"Method Suppository";
static NSString *const kMedicineMethodInfusion      = @"Method Infusion";
static NSString *const kMedicineNameMiss            = @"Name medicine can not be bank";
static NSString *const kMedicineQuantityMiss        = @"Quantity can not be bank";
static NSString *const KMethod                      = @"Method";
static NSString *const kMedicineListEmpty           = @"medicine.list.empty";

static NSString *const kTitleMedicineQuantity       = @"Quantity";
static NSString *const kTitleMedicineDose           = @"Dose";
static NSString *const kTitleMedicineFrequency      = @"Frequency";
static NSString *const kTitleMedicineUnit           = @"Unit";

static NSString *const kMedicineUnitCapsule = @"Unit Capsule";
static NSString *const kMedicineUnitPill = @"Unit Pill";
static NSString *const kMedicineUnitAmpoule = @"Unit Ampoule";

static NSString *const kMedicineDrinkDrug = @"Drink Drug";
static NSString *const kMedicineExternalDrug = @"External Drug";

static NSString *const kAddNewAlarm = @"Add New Alarm";
static NSString *const kPrescriptionList = @"Prescription List";
static NSString *const kPrescriptionName = @"Prescription Name";
static NSString *const kDrugName = @"Drug Name";
static NSString *const kRemider = @"Alert";
static NSString *const kDrugList = @"Drug List";
static NSString *const kDose = @"Dose";
static NSString *const kTakeYourMedicine = @"Take Your Medicine";
static NSString *const kDoseUnitTime = @"Dose(Unit/Time)";
static NSString *const kFrequencyTimeDay = @"Frequency(Time/Day)";
static NSString *const kQuantityDay = @"Quantity(Day)";
static NSString *const kAddNewDrug = @"Add new drug";
static NSString *const kCreatePrescriptionBeforeAdd = @"Please create prescription before add drugs";
static NSString *const kEnterPrescriptionName = @"Please enter prescription name";

//Medicine Unit
static NSString *const kMedicineUnitNothing    = @"Nothing";
static NSString *const kMedicineUnitSheet    = @"Sheet";
static NSString *const kMedicineUnitBook    = @"Book";
static NSString *const kMedicineUnitSet    = @"Set";
static NSString *const kMedicineUnitPiece    = @"Piece";
static NSString *const kMedicineUnitCapsuleDrug    = @"Capsule";
static NSString *const kMedicineUnitTablets    = @"Tablets made";
static NSString *const kMedicineUnitBaller    = @"Baller";
static NSString *const kMedicineUnitPackage    = @"Package";
static NSString *const kMedicineUnitBottle    = @"Bottle";
static NSString *const kMedicineUnitBag    = @"Bag";
static NSString *const kMedicineUnitTube    = @"Tube";
static NSString *const kMedicineUnitMilions    = @"Milions";
static NSString *const kMedicineUnitMg    = @"mg";
static NSString *const kMedicineUnitMl    = @"mL";
static NSString *const kMedicineUnitPipe    = @"Pipe";
static NSString *const kMedicineUnitCan    = @"Can";
static NSString *const kMedicineUnitLeaf    = @"Leaf";
static NSString *const kMedicineUnitMgTiter    = @"mg (titer)";
static NSString *const kMedicineUnitTiter    = @"μｇ (titer)";
static NSString *const kMedicineUnitAmpouleDrug  = @"Ampoule";
static NSString *const kMedicineUnitL    = @"L";
static NSString *const kMedicineUnitCm2    = @"cm2";
static NSString *const kMedicineUnitMBq    = @"MBq";
static NSString *const kMedicineUnitKit    = @"Kit";
static NSString *const kMedicineUnitTool    = @"Tool";
static NSString *const kMedicineUnitMlg    = @"mL (g)";
static NSString *const kMedicineUnitBlister    = @"Blister";

// Course Note
static NSString *const kTitleCourseNote    = @"Process Course Note";
static NSString *const kHospitalNul        = @"Hospital can not be bank";
static NSString *const kMaxUploadFile      = @"Exceed Maximum Number Of Selection";
static NSString *const kPatientRecord      = @"Patient Record";
static NSString *const kOrderList          = @"Order List";

// Diseases
static NSString *const kTitleHealthRecord = @"Health Record";
static NSString *const kTitleDiseases = @"Diseases/Injuries";
static NSString *const kNoImage       = @"Please choose image to upload";

static NSString *const kStartDate       = @"START DATE";
static NSString *const kEndDate       = @"END DATE";
static NSString *const kHospitalnameUpperCase       = @"HOSPITAL_UPPER";
static NSString *const kDiseasesName                    = @"DISEASES NAME";
static NSString *const kOutCome                             = @"OUT COME";

// Temperature
static NSString *const KTitleTemperature    = @"Temperature/Physiology";
static NSString *const kUnitCelsius         = @"Celsius";
static NSString *const kUnitFahrenheit      = @"Fahrenheit";
static NSString *const KTemperature         = @"TEMPERATURE";
static NSString *const KHeartRate           = @"HEART RATE";
static NSString *const KPrespiratory        = @"RESPIRATORY";
static NSString *const KBloodPressure       = @"BLOOD PRESSURE";
static NSString *const kPulses              = @"Pulses";
static NSString *const kAddNewTemperature   = @"Add new temperature";
static NSString *const kAddNewHeartRate     = @"Add new heart rate";
static NSString *const kAddNewRespiratory   = @"Add new respiratory";
static NSString *const kAddNewBloodPressure = @"Add new blood pressure";
static NSString *const kDottedTemperature   = @"᛫Temperature";
static NSString *const kDottedBloodPressure = @"᛫Blood Pressure";
static NSString *const kDottedHeartRate     = @"᛫Heart rate";
static NSString *const kDottedRespiratory   = @"᛫Respiratory";

// Sleep
static NSString *const kTitleLifeStyle      = @"Life Style";
static NSString *const kTitleStartSleeping  = @"Start sleeping";
static NSString *const kTitleWalkingUp      = @"Waking up";
static NSString *const kTitleSleepingTime   = @"Sleeping time";
static NSString *const kTitleRatingSleep    = @"RATING SLEEP";
static NSString *const kTitleTimeSleep      = @"Time sleep";

// Milk
static NSString *const kTitleMilk           =   @"Milk";
static NSString *const kTitleMotherMilk     =   @"Mother Milk";
static NSString *const kTitleBottleMilk     =   @"Bottle Milk";
static NSString *const kTitleAlert          =   @"Alert";
static NSString *const kTitleToday          =   @"Today";
static NSString *const kTitleAlertError     =   @"Error";
static NSString *const kTitleAlertComfirm   =   @"Confirm";
static NSString *const kTitleFeedTime       =   @"Feed time";
static NSString *const kMilkMissTimeOrKcal  =   @"Time and Kcal can not be bank";
static NSString *const kMilkMissType        =   @"Milk type can not be bank";
static NSString *const kMilkMissVolume      =   @"Volume and Kcal can not be bank";



static NSString *const kNoInput = @"No Input";

// >>>>>> Baby <<<<<<
static NSString *const kSelectColor = @"Select Color";
// --- Home ---
static NSString *const kBabyTitleTimeline = @"Child Tab Timeline";
static NSString *const kBabyTitleMedicine = @"Child Tab Medicines";
static NSString *const kBabyTitleVaccine = @"Child Tab Vaccines";
static NSString *const kBabyTitleFood = @"Child Tab Food";
static NSString *const kBabyTitleGrowth = @"Child Tab Growth";
static NSString *const kBabyTitleMilk = @"Child Tab Milk";
static NSString *const kBabyTitleDiaper = @"Child Tab Diaper";
static NSString *const kBabyTitleSleep = @"Child Tab Sleep";

// ------ Profile ------
static NSString * const kSon = @"Son";
static NSString * const kDaughter = @"Daughter";
static NSString * const kNiece = @"Niece";
static NSString * const kNephew = @"Nephew";

// Diaper
static NSString *const kDiaperStateDry              = @"Dry";
static NSString *const kDiaperStateWet              = @"Wet";
static NSString *const kDiaperStateSolid            = @"Solid";
static NSString *const kPoo = @"Poo";
static NSString *const kPee = @"Pee";
static NSString *const kState = @"State";
static NSString *const kColor = @"Color";

// ------ Growth ------
static NSString *const kGrowthHeight            = @"Height";
static NSString *const kGrowthWeight            = @"Weight";
static NSString *const kGrowthHeadSize          = @"Head Size";
static NSString *const kHeightNull              = @"Height can not be bank";
static NSString *const kHeadSizeNull            = @"Head size can not be bank";
static NSString *const kWeightNull              = @"Weight can not be bank";
static NSString *const kGrowthRecord            = @"Growth Record";

// >>>>>> SETTING <<<<<<
//Display setting
static NSString *const kTitleChooseBackgrounds          =   @"Choose background";
static NSString *const kTitleAddYourBackgrounds          =   @"Add your background";
static NSString *const kTitleDisplaySetting          =   @"Display Setting";
static NSString *const kLabelPreview          =   @"Preview";
static NSString *const kLabelSelected          =   @"Selected";
static NSString *const kLabelRecentUpload          =   @"Recent Upload";

// >>>>>> Common <<<<<<
static NSString *const kCommonRequestFail = @"common.request.fail";
static NSString *const kHour    = @"Hours";
static NSString *const kMinute  = @"Minutes";
static NSString *const kSecond  = @"Seconds";

static NSString *const kFailChangePass     = @"change.password.fail";
//static NSString *const kCaloriess          = @"Calories";
static NSString *const kRiceGruel              = @"Rice gruel";
static NSString *const kBabyFood              = @"Baby food";
static NSString *const kFruit              = @"Fruit";
static NSString *const kOther           = @"Other";
static NSString *const kTitleActionSheet   = @"Select Unit option";
static NSString *const kErrorConectToHost  = @"Error connect to host";
static NSString *const kTitleDeleteImage   = @"Please select a photo for upload";

// Clinic
static NSString *const kHospitalName = @"Hospital name";
static NSString *const kHospitalCode = @"Hospital code";
static NSString *const kSetActive = @"Set active";
static NSString *const kDelete = @"Delete";
static NSString *const kTagName = @"Tag name";
static NSString *const kOrder = @"Order type";
static NSString *const kClassification = @"Classification";
static NSString *const kOrderName = @"Order name";
static NSString *const kSearchByName = @"Search by name";
static NSString *const kPhone = @"Phone";
static NSString *const kCountry = @"Country";
static NSString *const kSearchNow = @"Search now";
static NSString *const kAll = @"All";
static NSString *const kVietnam = @"Vietnam";
static NSString *const kJapan = @"Japan";

static NSString *const kAddAccountSuccessfully = @"Add account successfully";
static NSString *const kDeleteAccountSuccessfully = @"Delete account successfully";
static NSString *const kAddAccountFail = @"Add account failure";
static NSString *const kDeleteAccountFail = @"Delete account failure";
static NSString *const kDeleteAccountConfirm = @"delete.account.confirm";

//Fitness
static NSString *const kTitleFitness = @"Fitness";
static NSString *const kChartStepCount = @"STEP COUNT";
static NSString *const kChartStepCountLowCase = @"Step Count";
static NSString *const kDottedStepCount = @"᛫Step Count";
static NSString *const kDottedWalkingRunDistance = @"᛫Walking, Running Distance";
static NSString *const kChartWalkingRunDistance = @"WALKING RUN DISTANCE";
static NSString *const kChartWalkingRunDistanceLowCase = @"Walking, Running Distance";
static NSString *const kChartAddNewStepCount = @"Add new Steps Count";
static NSString *const kChartAddNewWalkingRunDistance = @"Add new Walking, Run Distance";
static NSString *const kSteps = @"Steps";
static NSString *const kMissStepCount = @"Please Enter Steps Count";
static NSString *const kMissWalkingRunDistance = @"Please Enter Walking, Run Distance";
static NSString *const kStepNumberInvalid = @"Please enter step count as a number";
static NSString *const kWalkingRunNumberInvalid = @"Please enter walking, run distance as a number";

static NSString *const kFacebookIdIsRequired = @"facebook.id.required";
static NSString *const kEmailIsRequired = @"email.required";
static NSString *const kBirthdayIsRequired = @"birth.required";
static NSString *const kFacebookAccessTokenInvalid = @"facebook.access.token.invalid";
static NSString *const kFacebookIdInvalid = @"facebook.id.invalid";
static NSString *const kFacebookIdInUse = @"facebook.id.in.used";
static NSString *const kGenderRequired = @"gender.required";
static NSString *const kBirthdayRequired = @"birthday.required";
static NSString *const kFailLoginFacebook = @"fail.login.facebook";
static NSString *const kFailRegisterFacebook = @"fail.register.facebook";
static NSString *const kFailInput = @"fail.input";
static NSString *const kTextInputLong = @"Input is too long";
static NSString *const kNoData = @"No Data";
static NSString *const kFBNotAccessSystemSetting = @"verify.device.settings";

//HealthKit
static NSString *const kTitleSyncHealthKit = @"Synchronize HealthKit";
static NSString *const kTitleSyncBluetooth = @"Bluetooth";
static NSString *const kAllowReadData = @"Allow PHR to read data";
static NSString *const kAllowWriteData = @"Allow PHR to write data";
static NSString *const kAllowSync3G = @"Allow synchronize data to cloud by 3G";
static NSString *const kAllowAccessData = @"Allow access data";
static NSString *const kSyncSetting = @"Sync Setting";

//MovieTalk
static NSString *const kTitleMovieTalk = @"Movie Talk";
static NSString *const kTitleBookingList = @"My Booking";
static NSString *const kTitleBookingHistory = @"Booking History";
static NSString *const kMT06PatientId = @"patient_id";
static NSString *const kMT06PatientCode = @"patient_code";
static NSString *const kMT06HospitalCode = @"hosp_code";
static NSString *const kMT06Data = @"data";
static NSString *const kKC23HospitalName = @"hosp_name";
static NSString *const kKC23Locale = @"locale";
static NSString *const kKC23Data = @"data";
static NSString *const kPatientClinicHeaderTitle = @"Please choose corresponding clinic to show your online booking";
static NSString *const kMyOnlineBooking = @"My Online Booking";
static NSString *const kPHR03ListAccountClinic = @"list_account_clinic";
static NSString *const kReceiveCallingFrom = @"Receive Calling From";
static NSString *const kPleaseAllowCameraMovieTalk = @"Please allow camera access for Movie Talk";

//Add new medicine
static NSString *const kTitleAddReminder = @"Add new remind";
static NSString *const kDays = @"Days";
static NSString *const kDay = @"Day";
static NSString *const kExpireAfter = @"Expire After" ;

//Chat
static NSString *const kOnline = @"Online";
static NSString *const kOffline = @"Offline";
static NSString *const kNotDelivered = @"Not delivered";
static NSString *const kSend = @"Send";
static NSString *const kTextMessage = @"Text Message";
static NSString *const kReceiveACallFrom = @"Receive calling from doctor";

#endif
