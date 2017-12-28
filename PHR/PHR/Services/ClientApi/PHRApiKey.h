//
//  PHRApiKey.h
//  PHR
//
//  Created by Luong Le Hoang on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#ifndef PHRApiKey_h
#define PHRApiKey_h

// ----------------------------------------- Account ----------------------------------------
// Common
static NSString * const KEY_FAIL = @"FAIL";
static NSString * const KEY_SUCCESS = @"SUCCESS";
static NSString * const  KEY_Status = @"status";
static NSString * const  KEY_Message = @"message";
static NSString * const KEY_Token = @"token";
static NSString * const  KEY_Note = @"note";
static NSString * const KEY_Source = @"source";
static NSString * const KEY_FAMILY_TYPE_MEMBER = @"MEMBER";
static NSString * const KEY_FAMILY_TYPE_PERSONAL = @"PERSONAL";
static NSString * const KEY_APNS_REGISTER_ID = @"KEY_APNS_REGISTER_ID";
static NSString * const KEY_DEVICE_TOKEN = @"device_token";

// Register
static NSString * const API_Register = @"api/accounts/register";
static NSString * const  KEY_Email = @"email";
static NSString * const  KEY_Profile = @"profile";
static NSString * const KEY_FullName = @"full_name";
static NSString * const KEY_FullNameKana = @"full_name_kana";
static NSString * const KEY_Birthday = @"birthday";
static NSString * const KEY_NickName = @"nickname";
static NSString * const KEY_Gender = @"gender";
static NSString * const  KEY_FamilyMemberType = @"family_member_type";
static NSString * const  KEY_BabyFlag = @"baby_flg";
static NSString * const KEY_Relationship = @"relationship";
static NSString * const KEY_Standard_Udid = @"standard_udid";
static NSString * const KEY_Baby_Udid = @"baby_udid";
static NSString * const KEY_is_Fist_Sync = @"is_fist_sync";
static NSString * const KEY_Latest_Sync_Time = @"latest_sync_time ";
//Login Facebook
static NSString * const API_Login_Facebook = @"api/accounts/login_facebook";

//Agreement
static NSString * const API_ChangeStatusAgreement = @"api/accounts/%@/change_status_agreement";

//Register FaceBook
static NSString * const API_Register_Facebook = @"api/accounts/register_facebook";
static NSString * const KEY_AccessToken = @"access_token";
static NSString * const KEY_FacebookId = @"facebook_id";
static NSString * const KEY_Name = @"name";
static NSString * const KEY_First_Name = @"first_name";
static NSString * const KEY_Last_Name = @"last_name";
static NSString * const KEY_ProfileImageURL = @"profile_image_url";

//Authenticate Facebook
static NSString * const KEY_ID = @"id";
static NSString * const KEY_Picture = @"picture";
static NSString * const KEY_Data = @"data";
static NSString * const KEY_URL = @"url";

// Profile
static NSString * const KEY_ProfileId    = @"profile_id";
static NSString * const API_SearchHospital = @"/api/kcck/get_hospital_name";
static NSString * const API_ClinicAdd = @"/api/profiles/%@/clinic_account";
static NSString * const API_ClinicDelete = @"/api/profiles/%@/clinic_account/%@";
static NSString * const API_ClinicSetActive = @"api/profiles/%@/clinic_account/set_active_profile/%@";
static NSString * const KEY_Age  = @"age";

// Login
static NSString * const RESULT_FirstChangePassRequired = @"fail.first.change.password.required";
static NSString * const API_Login = @"api/accounts/login";
static NSString const * KEY_Password = @"password";
static NSString const * KEY_Udid = @"udid";
static NSString * const KEY_BabyBackgroundUrl = @"baby_background_url";
static NSString * const KEY_BabyProfileId = @"baby_profile_id";
static NSString * const KEY_StandardBackgroundUrl = @"standard_background_url";
static NSString * const KEY_StandardProfileId = @"standard_profile_id";
static NSString * const KEY_Type = @"type";
static NSString * const KEY_LoginType = @"login_type";
// Change password
static NSString * const API_ChangePassword = @"api/accounts/change_password";
static NSString const * KEY_NewPassword = @"new_password";

// Forgot password
static NSString * const API_ForgotPassword = @"api/accounts/reset_password";

// Logout
static NSString * const API_Logout = @"api/accounts/logout";

// ----------------------------------------- Profile ----------------------------------------
// Standard Home
static NSString * const API_StandardHomePage = @"api/profiles/standard_profile/%@/homepage";

// Profile
static NSString * const API_FamilyList = @"api/profiles";
static NSString * const API_ProfileSetActive = @"api/profiles/set_active_profile/%@?type=%@&udid=%@";
static NSString * const API_HomeStandard = @"api/profiles/standard_profile/%@/homepage";

// Standard
static NSString * const API_StandardProfile = @"api/profiles/standard_profile";
static NSString * const KEY_ActiveProfileFlag = @"active_profile_flg";
static NSString * const KEY_PictureProfileUrl = @"picture_profile_url";
static NSString * const KEY_AccountId = @"account_id";
static NSString * const KEY_Address = @"address";
static NSString * const KEY_City = @"city";
static NSString * const KEY_Locale = @"locale";
static NSString * const KEY_Occupation = @"occupation";
static NSString * const KEY_Prefecture = @"prefecture";
static NSString * const KEY_ZipCode = @"zip_code";
static NSString * const KEY_ListAccountClinic = @"list_account_clinic";
// Clinic
static NSString * const KEY_UserName = @"user_name";

// Baby
static NSString * const API_BabyProfile = @"api/profiles/baby_profile";
static NSString * const KEY_BabyGrowthModel = @"baby_growth_model";
static NSString * const KEY_BabyGrowthHeightMode = @"baby_growth_height_mode";
static NSString * const KEY_BabyGrowthWeightMode = @"baby_growth_weight_mode";

//Change background standard view
static NSString * const API_ChangeBackgroundST  = @"api/accounts/standard_change_background";
static NSString * const KEY_Standard_URL        = @"standard_background_url";

static NSString * const API_ChangeBackgroundBB  = @"api/accounts/baby_change_background";
static NSString * const KEY_Baby_URL            = @"baby_background_url";

// ----------------------------------------- Health ----------------------------------------
/* old api
static NSString * const API_StandardHealthAddNew = @"api/profiles/%@/standard_health";
 */
//New Api Body Measurement
static NSString * const API_StandardHealthAddNew = @"/api/profiles/%@/standard_health/health_type/%@/health";
static NSString * const API_StandardHealthEdit = @"api/profiles/%@/standard_health/health_type/%@/health/%@";
static NSString * const API_StandardHealthDelete = @"api/profiles/%@/standard_health/health_type/%@/%@";
static NSString * const API_StandardHealtGetDetail = @"api/profiles/%@/standard_health/health_type/%@/health/%@";
static NSString * const API_StandardHealtGetListWithDuration = @"api/profiles/%@/standard_health/health_type/%@/duration_type/%@";
static NSString * const API_StandardHealtGetListTimeLine = @"api/profiles/%@/standard_health/health_type/%@?page_number=%@&page_size=10";
//-------------//


static NSString * const API_StandardHealthGetList = @"/api/profiles/%@/standard_health?limit_page_number=%d&limit_page_size=10";
static NSString * const API_StandardHealthGetDetail = @"/api/profiles/%@/standard_health/%@";
//Old API
static NSString * const API_StandardHealthEditOrDelete = @"/api/profiles/%@/standard_health/%@";

static NSString * const KEY_DateRecord = @"datetime_record";
static NSString * const KEY_Height = @"height";
static NSString * const KEY_Weight = @"weight";
static NSString * const KEY_WaistLine = @"waist_line";
static NSString * const KEY_ChestSize = @"chest_size";
static NSString * const KEY_LowBloodPress = @"low_blood_press";
static NSString * const KEY_HighBloodPress = @"high_blood_press";
static NSString * const KEY_PercentageFat = @"perc_fat";
static NSString * const KEY_BMI = @"bmi";
static NSString * const KEY_HEALTH_ID = @"health_id";
static NSString * const KEY_HEALTH_TYPE = @"health_type";
static NSString * const KEY_Health_Info = @"health_info";
static NSString * const KEY_Height_Info = @"height_info";
static NSString * const KEY_Percent_Fat_Info = @"perc_fat_info";
static NSString * const KEY_Weight_Info = @"weight_info";
static NSString * const KEY_Bmi_Info = @"bmi_info";

// ------------------------------------- Life Style Note ------------------------------------
static NSString * const API_GetListLifeStyleNote        = @"/api/profiles/%@/standard_life_style?limit_page_number=%d&limit_page_size=10";
static NSString * const API_AddNewLifeStyleNote         = @"api/profiles/%@/standard_life_style";
static NSString * const API_LifeStyleNote               = @"api/profiles/%@/standard_life_style/%@";
static NSString * const API_StandardLifeStyleGetListWithDuration = @"api/profiles/%@/standard_life_style/duration_type/%@";
static NSString * const KEY_LifeStyleNote_Time_Sleep    = @"time_start_sleep";
static NSString * const KEY_LifeStyleNote_Time_WakeUp   = @"time_wake_up";
static NSString * const KEY_LifeStyleNote_Total_time    = @"total_hour_sleep";
static NSString * const KEY_LifeStyleNote_Rating_Sleep  = @"rating_sleep";
static NSString * const KEY_LifeStyleNote_Time_Awake    = @"time_awake";

// ----------------------------------------- Medicines ----------------------------------------
static NSString * const API_StandardMedicines       = @"api/profiles/%@/medicine_note?page_number=%d&page_size=10";
static NSString * const API_Prescription       = @"api/profiles/%@/medicine_note/%@?page_number=%d&page_size=10";

static NSString * const KEY_Prescription_ID        = @"prescription_id";
static NSString * const KEY_Prescription_Name        = @"prescription_name";
static NSString * const KEY_Prescription_Note      = @"note";
static NSString * const KEY_Prescription_URL     = @"prescription_url";
static NSString * const KEY_Prescription_Time          = @"datetime_record";

static NSString * const KEY_Drug_ID = @"id";
static NSString * const KEY_Drug_Name = @"name";
static NSString * const KEY_Drug_Method = @"method";
static NSString * const KEY_Drug_Dose = @"dose";
static NSString * const KEY_Drug_Note = @"note";
static NSString * const KEY_Drug_Quantity = @"quantity";
static NSString * const KEY_Drug_Time = @"time_take_medicine";
static NSString * const KEY_Drug_Unit = @"unit";
static NSString * const KEY_Drug_Frequency = @"frequency";



// ----------------------------------------- Get Medicine ----------------------------------------
static NSString * const API_StandardGetMedicine     = @"api/profiles/%@/medicine_note/%@";

///api/profiles/:id_profile/medicine_note/:id_medicine
// ----------------------------------------- Add Medicine Note ----------------------------------------
static NSString * const API_AddNewMedicineNote       = @"api/profiles/%@/medicine_note";
static NSString * const API_MedicineNote             = @"api/profiles/%@/medicine_note/%@";
static NSString * const API_NewDrug                  = @"/api/profiles/%@/medicine_note/%@/medicine";
static NSString * const API_UpdateDrug               = @"/api/profiles/%@/medicine_note/%@/medicine/%@";

static NSString * const KEY_MedicineNote_Time        = @"time_take_medicine";
static NSString * const KEY_MedicineNote_Name        = @"name";
static NSString * const KEY_MedicineNote_Method      = @"method";
static NSString * const KEY_MedicineNote_Quantity    = @"quantity";
static NSString * const KEY_MedicineNote_Unit        = @"unit";
static NSString * const KEY_MedicineNote_Dose        = @"dose";
static NSString * const KEY_MedicineNote_Pre_URL     = @"prescription_url";
static NSString * const KEY_MedicineNote_ID          = @"id";

// ----------------------------------------- Progress Course ----------------------------------------
static NSString * const API_AddNewProgressCourse      = @"api/profiles/%@/standard_progress_course";
static NSString * const API_GetDetailProgressCourse   =@"/api/profiles/%@/standard_progress_course_detail";
static NSString * const API_GetMedicineNote_ProgressCourse  = @"api/kcck/get_medicine?patient_code=%@&hosp_code=%@";
static NSString * const KEY_ProgressCourse_Hospital   = @"hospital";
static NSString * const KEY_ProgressCourse_Status     = @"status";
static NSString * const KEY_ProgressCourse_Record_Url = @"medical_record_url";

// ----------------------------- Progress Course - Medicine Note ----------------------------------------
//static NSString * const KEY_Medicine_List = @"medicine_list_xx";
static NSString * const KEY_Hosp_Name = @"hosp_name";

// ----------------------------------------- Food ----------------------------------------
//static NSString * const API_StandardFoodAddNew  = @"api/profiles/%@/standard_food";
static NSString * const API_GetListStandardFood = @"/api/profiles/%@/standard_food?limit_page_number=%d&limit_page_size=10";
static NSString * const API_DetailStandardFood  = @"api/profiles/%@/standard_food/%@";
static NSString * const KEY_EatingTime = @"eating_time";
static NSString * const KEY_Rating = @"rating";
static NSString * const KEY_Kcal = @"kcal";
static NSString * const KEY_StandardFoodId = @"standard_food_id";

// ----------------------------------------- Tempeture ----------------------------------------
static NSString * const API_GetListTemperature      = @"/api/profiles/%@/standard_temperature?limit_page_number=%d&limit_page_size=10";
static NSString * const API_GetTimeLineTemperature  = @"api/profiles/%@/standard_temperature/temperature_type/%@?page_number=%@&page_size=10";
static NSString * const API_AddNewTempeture         = @"api/profiles/%@/standard_temperature";
static NSString * const API_UpdateTempeture         = @"api/profiles/%@/standard_temperature/temperature_type/%@/temperature/%@";
static NSString * const API_Tempeture               = @"api/profiles/%@/standard_temperature/%@";
static NSString * const API_TemperatureDelete       = @"/api/profiles/%@/standard_temperature/temperature_type/%@/temperature/%@";

static NSString * const KEY_Tempeture_Date          = @"date_measure";
static NSString * const KEY_Tempeture_Tempeture     = @"temperature";
static NSString * const KEY_Unit                    = @"unit";
static NSString * const KEY_Unit_C                  = @"C";
static NSString * const KEY_Unit_F                  = @"F";

static NSString * const KEY_TEMPERATURE_ID          = @"temperature_id";
static NSString * const KEY_TEMPERATURE             = @"temperature";
static NSString * const KEY_HEART_RATE              = @"pulse";
static NSString * const KEY_HEART_RATE_MIN          = @"min_pulse";
static NSString * const KEY_HEART_RATE_MAX          = @"max_pulse";
static NSString * const KEY_RESPIRATORY             = @"breath";
static NSString * const KEY_LOW_BLOOD_PRESSURE      = @"low_blood_pressure";
static NSString * const KEY_HIGH_BLOOD_PRESSURE     = @"high_blood_pressure";
static NSString * const KEY_MAX_HIGH_BLOOD_PRESSURE = @"max_high_blood_pressure";
static NSString * const KEY_MAX_LOW_BLOOD_PRESSURE        = @"max_low_blood_pressure";
static NSString * const KEY_MIN_HIGH_BLOOD_PRESSURE       = @"min_high_blood_pressure";
static NSString * const KEY_MIN_LOW_BLOOD_PRESSURE        = @"min_low_blood_pressure";

static NSString * const KEY_Temperature_Info        = @"temperature_info";
static NSString * const KEY_HeartRate_Info          = @"heartrate_info";
static NSString * const KEY_Respiratory_Info        = @"respiration_rate_info";
static NSString * const KEY_Blood_Pressure_Info     = @"blood_pressure_info";


static NSString * const API_StandardTemperatureGetListWithDuration = @"api/profiles/%@/standard_temperature/temperature_type/%@/duration_type/%@";
static NSString * const API_StandardAddNewTemperature = @"/api/profiles/%@/standard_temperature/temperature_type/%@";

// ----------------------------------------- Growth ----------------------------------------
static NSString * const API_GetListGrowth       = @"api/profiles/%@/baby_growth?limit_page_number=%d&limit_page_size=10";
static NSString * const API_AddNewGrowth        = @"api/profiles/%@/baby_growth";
static NSString * const API_DeleteOrGetGrowth   = @"api/profiles/%@/baby_growth/%@";
static NSString * const KEY_TimeMeasure         = @"time_measure";
static NSString * const KEY_HeadSize            = @"head_size";
static NSString * const KEY_DoctorNote          = @"doctor_note";
static NSString * const KEY_ParentNote          = @"parent_note";
static NSString * const KEY_MedicalRecordUrl    = @"medical_record_url";
static NSString * const KEY_GrowthID            = @"growth_id";

// ----------------------------------------- Diseases ----------------------------------------
static NSString * const API_AddNewDiseases         = @"api/profiles/%@/standard_disease";
static NSString * const API_GetListDiseases         = @"/api/profiles/%@/standard_disease?limit_page_number=%@&limit_page_size=10";
static NSString * const API_StandardDiseases       = @"/api/profiles/%@/standard_disease/%@";
static NSString * const KEY_disease_list                  = @"disease.list";
static NSString * const KEY_disease_id                  = @"disease_id";
static NSString * const KEY_datetime_record                  = @"datetime_record";
static NSString * const KEY_hospital_name                  = @"hospital";
static NSString * const KEY_disease_name                  = @"disease_name";
static NSString * const KEY_start_date                  = @"start_date";
static NSString * const KEY_end_date                  = @"end_date";
static NSString * const KEY_outcome                  = @"outcome";

// ------------------------------------- Health-Diagnosis ------------------------------------
static NSString * const API_HealthDiagnosis         = @"api/profiles/%@/standard_health_diagnosis";

// ---------------------------------------- Baby Sleep ---------------------------------------
static NSString * const API_GetListBabySleep       = @"api/profiles/%@/baby_sleep?limit_page_number=%d&limit_page_size=10";
static NSString * const API_AddBabySleep           = @"api/profiles/%@/baby_sleep";
static NSString * const API_DeleteBabySleep        = @"api/profiles/%@/baby_sleep/%d";
static NSString * const KEY_BabySleep_Morning      = @"morning_time_sleep";
static NSString * const KEY_BabySleep_Afternoon    = @"afternoon_time_sleep";
static NSString * const KEY_BabySleep_Night        = @"night_time_sleep";
static NSString * const KEY_Alert                  = @"alert";

// ---------------------------------------- Baby Milk ---------------------------------------
static NSString * const API_GetListBabyMilk        = @"api/profiles/%@/baby_milk?limit_page_number=%d&limit_page_size=10";
static NSString * const API_AddNewBabyMilk         = @"api/profiles/%@/baby_milk";
static NSString * const API_UpdateBabyMilk         = @"/api/profiles/%@/baby_milk/%@";
static NSString * const API_DeleteBabyMilk         = @"/api/profiles/%@/baby_milk/%@";
static NSString * const KEY_BabyMilk_Time          = @"time_drink_milk";
static NSString * const KEY_BabyMilk_Method        = @"drink_method";
static NSString * const KEY_BabyMilk_BreastTime    = @"breast_time";
static NSString * const KEY_BabyMilk_Bottle_Milk   = @"bottle_milk_volume";
static NSString * const KEY_BabyMilk_Type          = @"milk_type";

// ---------------------------------------- Baby Diaper ---------------------------------------
static NSString * const API_GetListBabyDiapers     = @"api/profiles/%@/baby_diaper?limit_page_number=%d&limit_page_size=10";
static NSString * const API_AddNewBabyDiaper       = @"api/profiles/%@/baby_diaper";
static NSString * const API_UpdateBabyDiaper       = @"/api/profiles/%@/baby_diaper/%d";
static NSString * const API_GetDetailBabyDiaper    = @"/api/profiles/%@/baby_diaper/%@";
static NSString * const KEY_BabyDiaper_Time        = @"time_pee_poo";
static NSString * const KEY_BabyDiaper_Color       = @"color";
static NSString * const KEY_BabyDiaper_State       = @"state";
static NSString * const KEY_BabyDiaper_ID          = @"diaper_id";

// ---------------------------------------- Baby Food ---------------------------------------
static NSString * const API_GetListBabyFood      = @"api/profiles/%@/baby_food?limit_page_number=%d&limit_page_size=10";
static NSString * const API_AddNewBabyFood       = @"api/profiles/%@/baby_food";
static NSString * const API_GetDetailBabyFood    = @"/api/profiles/%@/baby_food/%@";
static NSString * const API_UpdateBabyFood       = @"/api/profiles/%@/baby_food/%@";
static NSString * const KEY_BabyFood_Time        = @"eating_time";
static NSString * const KEY_BabyFood             = @"food";
static NSString * const KEY_BabyFood_Kcal        = @"calories";
static NSString * const KEY_BabyFood_ImgURL      = @"image_url";
static NSString * const KEY_BabyFood_Meal_Type   = @"meal_type";

// ---------------------------------------- Baby TimeLine ---------------------------------------
static NSString * const API_GetListBabyTimeLine  = @"api/profiles/baby_profile/%@/homepage?limit=%d";


//New Food Api
static NSString * const API_StandardFoodAddNew = @"/api/profiles/%@/standard_food/food_type/%@/food";
static NSString * const API_StandardFoodEdit = @"api/profiles/%@/standard_food/food_type/%@/food/%@";
static NSString * const API_StandardFoodGetListWithDuration = @"api/profiles/%@/standard_food/food_type/%@/duration_type/%@";
static NSString * const API_StandardFoodGetDetail = @"api/profiles/%@/standard_food/food_type/%@/food/%@";
static NSString * const API_StandardFoodGetListTimeLine = @"api/profiles/%@/standard_food/food_type/%@?page_number=%@&page_size=10";
static NSString * const API_StandardFoodDelete = @"api/profiles/%@/standard_food/food_type/%@/food/%@";

static NSString * const KEY_Calories_Info = @"calories_info";
static NSString * const KEY_Carbodydrate_Info = @"carbohydrate_info";
static NSString * const KEY_Total_Fat_Info = @"total_fat_info";

static NSString * const KEY_Food_ID = @"food_id";
static NSString * const KEY_Eating_Time = @"eating_time";
static NSString * const KEY_Calories = @"calories";
static NSString * const KEY_Carbohydrate = @"carbohydrate";
static NSString * const KEY_Total_Fat = @"total_fat";
static NSString * const KEY_Rating_Satisfied = @"rating_satisfied";
static NSString * const KEY_Food_Data = @"food_data";

//Fitness API
static NSString * const API_StandardFitnessAddNew = @"api/profiles/%@/standard_fitness/fitness_type/%@/fitness";
static NSString * const API_StandardFitnessGetListWithDuration = @"api/profiles/%@/standard_fitness/fitness_type/%@/duration_type/%@";
static NSString * const API_StandardFitnessGetListTimeLine = @"api/profiles/%@/standard_fitness/fitness_type/%@?page_number=%@&page_size=10";
static NSString * const API_StandardFitnessDelete = @"api/profiles/%@/standard_fitness/fitness_type/%@/fitness/%@";
static NSString * const API_StandardFitnessGetDetail = @"api/profiles/%@/standard_fitness/fitness_type/%@/fitness/%@";

static NSString * const KEY_Fitness_ID = @"fitness_id";
static NSString * const KEY_Fitness_Date = @"datetime_record";
static NSString * const KEY_Step_Count = @"steps_count";
static NSString * const KEY_Walking_Run = @"walk_run_distance";
static NSString * const KEY_Step_Info = @"steps_count_info";
static NSString * const KEY_WalkRun_Info = @"walk_run_distance_info";
static NSString * const KEY_Fitness_Data = @"fitness_data";


//New Baby Food API
static NSString * const API_BabyFoodGetListWithDuration = @"api/profiles/%@/baby_food/duration_type/%@";

static NSString * const KEY_Baby_Food_Info = @"baby_food_info";
static NSString * const KEY_Baby_Food_Id = @"food_id";

//New Baby Growth API
static NSString * const API_BabyGrowthAddNew = @"api/profiles/%@/baby_growth/growth_type/%@";
static NSString * const API_BabyGrowthGetListWithDuration = @"api/profiles/%@/baby_growth/growth_type/%@/duration_type/%@";
static NSString * const API_BabyGrowthGetDetail = @"api/profiles/%@/baby_growth/growth_type/%@/growth/%@";
static NSString * const API_BabyGrowthGetListTimeLine = @"api/profiles/%@/baby_growth/growth_type/%@?page_number=%@&page_size=10";
static NSString * const API_BabyGrowthDelete = @"api/profiles/%@/baby_growth/growth_type/%@/growth/%@";
static NSString * const API_BabyGrowthEdit = @"api/profiles/%@/baby_growth/growth_type/%@/growth/%@";

static NSString * const KEY_Growth_Info = @"growth_info";
static NSString * const KEY_Growth_ID       = @"growth_id";

//API Synchronize PHR to Server
static NSString * const API_SyncStandardBodyMeasurement = @"api/profiles/%@/standard_health_list/health?udid=%@";
static NSString * const API_SyncStandardTemperature = @"api/profiles/%@/standard_temp_list/temperature_type/%@?udid=%@";
static NSString * const API_SyncStandardFood = @"api/profiles/%@/standard_food_list/food_type/%@/food?udid=%@";
static NSString * const API_SyncStandardLifeStyle = @"api/profiles/%@/standard_life_style_list?udid=%@";
static NSString * const API_SyncStandardFitness = @"api/profiles/%@/standard_fitness_list/fitness_type/%@/fitness?udid=%@";

static NSString * const API_SyncBabyGrowth = @"api/profiles/%@/baby_growth_list/growth_type/%@?udid=%@";

static NSString * const API_SyncActive = @"api/profiles/%@/set_active_sync_udid?udid=%@";

static NSString * const API_SyncValidateUDID = @"api/profiles/%@/validate_udid/%@";
// ------------------------------------- Synchronize  ------------------------------------
static NSString * const KEY_Health_List      = @"health_list";

// ------------------------------------- Movie Talk --------------------------------------
static NSString *const API_MT06 = @"mss/patient/get-patient-info-by-profile-id?profile_id=%@";
static NSString *const API_KC23 = @"cms/hospital/search?hosp_code=%@";
static NSString *const API_KC21 = @"mss/patient/waiting-list?examination_date=%@&hosp_code=%@&patient_code=%@&locale=%@";
static NSString *const API_MT03 = @"mss/patient/update-calling-id";
static NSString *const API_PHR03 = @"phr/api/profiles/standard_profile/%@?token=%@";
static NSString * const API_MT07 = @"mss/patient/get_list_movie_talk_history?hosp_code=%@&patient_code=%@&page_number=%@&page_size=%@";
#endif /* PHRApiKey_h */
