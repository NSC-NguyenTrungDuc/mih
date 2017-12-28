//
//  PHRClient.h
//  PHR
//
//  Created by Luong Le Hoang on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "AFNetworking.h"
#import "PHRApiKey.h"
#import "MedicineNote.h"
#import "ProgressCourse.h"
#import "Temperature.h"
#import "BabyGrowth.h"
#import "LifeStyleNoteModel.h"
#import "Diaper.h"
#import "BabyTimeLineResponse.h"
#import "MFRession.h"
#import "FacebookProfile.h"
#import "DiseasesModel.h"
#import "StandardHealthModel.h"
#import "BodyMeasurementModel.h"
#import "FoodItem.h"
#import "FitnessModel.h"
#import "TemperaturePhysiologyModel.h"
#import "ChildrenFoodModel.h"
#import "DrugNote.h"

typedef void (^PHRResponseSuccess)(id);
typedef void (^PHRTaskResponseSuccess)(NSURLSessionDataTask*, id);
typedef void (^PHRResponseError)(NSString*);

@interface PHRClient : AFHTTPSessionManager {
    
}

+ (instancetype)instance;
// --------------------------------- Utils function -------------------------------
+ (BOOL)getStatusFromResponse:(id)responseObject;
+ (NSString*)getMessageFromResponse:(id)responseObject;
+ (NSString*)getTypeFromResponse:(id)responseObject;
+ (NSString*)getLoginTypeFromResponse:(id)responseObject;
+ (NSString*)getProfileStatusFromResponse:(id)responseObject;
+ (NSString*)getAccountIDFromResponse:(id)responseObject;

// -------------------------------------- Account flow --------------------------------------
- (void)requestRegisterWithProfile:(Profile*)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestRegisterWithFaceBook:(FacebookProfile*)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestLoginWithEmail:(NSString*)email password:(NSString*)pass completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestLoginWithFacebook:(NSString*)token completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestChangePassword:(NSString*)oldPass toNewPassword:(NSString*)newPass completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestResetPasswordForEmail:(NSString*)email completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestLogoutwithCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// -------------------------------------- Agreement ------------------------------------
- (void)requestChangeAgreementStatus:(NSString*)accountID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// -------------------------------------- Medicine --------------------------------------
- (NSURLSessionDataTask*)requestMedicinesWithApiID:(NSString *)apiId andNumberPage:(int)numberPage andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddNewMedicineWithObjNote:(BabyMedicineModel *)medicineNote andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDrugsWithApiID:(NSString *)apiId andPrescriptionId:(NSString *)presId andNumberPage:(int)numberPage andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddNewPrescription:(NSString *)prescriptionID andPres:(NSString *)prescriptionName andDate:(NSString*)date withArrayImages:(NSArray*)arrayImages completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddNewDrug:(NSDictionary *)params andPresID:(NSString *)presID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestUpdateDrug:(NSDictionary *)params andPresID:(NSString *)presID andDrugID:(NSString *)drugID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteDrug:(NSString *)presID andDrugID:(NSString *)drugID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeletePrescription:(NSString *)presID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// -------------------------------------- Progress Course --------------------------------------
- (void)requestAddNewProgressCourseWithObjNote:(ProgressCourse *)progressCourse andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestGetDetailProgressCourse:(NSString*)activeStandardId completion:(void (^)(MFRession *))completion;
- (void)requestGetListMedicineNoteForPatient:(NSString *)patientCode hospCode:(NSString*)hospCode completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
// -------------------------------------- Profile flow --------------------------------------
- (void)requestStandardProfileListCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestBabyProfileListCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestSetActiveStandard:(BOOL)isStandard newId:(NSString *)newId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// Clinic
- (void)requestSearchHospitalWithName:(NSString*)name address:(NSString*)address tel:(NSString*)tel country:(NSString*)country completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddClinicAccountName:(NSString*)name hospCode:(NSString*)code pass:(NSString*)pass profileId:(NSString*)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteClinicAccount:(NSString*)clinicId profileId:(NSString*)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestSetActiveClinicAccount:(NSString*)clinicId profileId:(NSString*)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// Standard
- (void)requestGetHomePageStandard:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestGetDetailStandardProfileId:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteStandardProfileId:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddNewStandardProfile:(ProfileStandard *)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestEditStandardProfile:(ProfileStandard *)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// Baby
- (void)requestAddNewBabyProfile:(ProfileBaby*)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteBabyProfileId:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestGetDetailBabyProfileId:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestEditBabyProfile:(ProfileBaby *)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// -------------------------------------- Life Style --------------------------------------
- (void)requestAddNewLifeStyle:(LifeStyleNoteModel *)lifeStyleNote completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestGetListLifeStyle:(NSString *)profileId andPageNumber:(int)numberPage completion:(void (^)(MFRession *))completion;
- (NSURLSessionDataTask*)requestGetListLifeStyleWithDuration:(NSString*)duration andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
// -------------------------------------- Diseases --------------------------------------
- (void)requestAddNewDiseases:(DiseasesModel *)diseases completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestGetListDiseases:(NSString *)numberPage completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (NSURLSessionDataTask*)requestGetListData:(NSString *)profileId andNumberPage:(int)numberPage andMethod:(NSString *)method completion:(void (^)(MFRession *))completion;
- (void)requestGetDetail:(NSString *)profileId and:(NSString *)objectId andMethod:(NSString *)method completion:(void (^)(MFRession *))completion;
- (void)requestDeleteObject:(NSString *)profileId and:(NSString *)objectId andMethod:(NSString *)method completion:(void (^)(MFResponse *))completion;
- (void)requestUpdateData:(NSString *)method andProdileId:(NSString *)profileId andObjectId:(NSString *)objectId withParam:(NSDictionary *)params
               completion:(void (^)(MFRession *))completion;

// -------------------------------------- Health --------------------------------------
//New body measurement
- (void)requestUpdateBodyMeasurement:(BodyMeasurementModel*)bodyItem andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (NSURLSessionDataTask*)requestGetListStandardHealthWithTypeAndDuration:(NSString *)profileId withHealthType:(int)healthType andDuration:(NSString*)duration completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteStandardHealth:(NSString *)healthId healthType:(NSString*) healthType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDetailBodyMeasurementWithId:(NSString *)healthId healthType:(NSString*)healthType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock;
- (NSURLSessionDataTask*)requestGetTimeLineBodyMeasurement:(NSString *)profileId withHealthType:(int)healthType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;


// -------------------------------------- Temperature --------------------------------------
- (NSURLSessionDataTask*)requestGetListTemperaturePhysiologyWithTypeAndDuration:(NSString *)profileId withTemperatureType:(int)healthType andDuration:(NSString*)duration completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddNewTemperaturePhysiology:(TemperaturePhysiologyModel *)temperatureItem completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestUpdateTemperature:(TemperaturePhysiologyModel*)temperatureItem andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteStandardTemperature:(NSString *)temperatureId temperatureType:(NSString*) temperatureType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (NSURLSessionDataTask*)requestGetTimeLineTemperature:(NSString *)profileId withTemperatureType:(int)temperatureType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDetailTemperatureWithId:(NSString *)temperatureID type:(NSString*)temperatureType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock;


// -------------------------------------- Baby Milk --------------------------------------
- (NSURLSessionDataTask*)requestGetListBabyMilkWithId:(NSString *)babyId andNumberPage:(int)numberPage completion:(void (^) (MFRession *responseObject))completion error:(PHRResponseError)errorBlock;
- (void)requestAddNewBabyMilkWithObj:(BabyMilkModel *)babyMilk andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddNewBottleMilk:(BabyMilkModel *)babyMilk andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestUpdateMilk:(BabyMilkModel *)babyMilk andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock ;

// -------------------------------------- Baby Diaper --------------------------------------
- (NSURLSessionDataTask*)requestGetListBabyDiapersWithId:(NSString *)babyID andNumberPage:(int)numberPage completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddNewBabyDiaperWithObj:(Diaper *)babyDiaper andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestUpdateDiaper:(Diaper *)babyDiaper andCompletion:(void (^) (MFRession *responseObject))completion error:(PHRResponseError)errorBlock;

// -------------------------------------- Baby Food --------------------------------------
- (NSURLSessionDataTask*)requestGetListBabyFoods:(NSString *)babyID andNumberPage:(int)numberPage completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestAddNewBabyFoodWithObj:(ChildrenFoodModel *)babyFood andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestGetDetailBabyFoodsWithId:(NSString *)babyID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestUpdateBabyFood:(ChildrenFoodModel*)babyFoodModel andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteBabyFood:(NSString *)babyFoodId andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
// -------------------------------------- Baby TimeLine --------------------------------------
- (void)requestGetListBabytimeLineWithId:(NSString *)babyID andNumberLimit:(int)limit completed:(void (^) (MFRession *responseObject))completion error:(PHRResponseError)errorBlock;

- (void)requestChangeBackgroundBaby:(NSString *)urlPhoto;
- (void)requestChangeBackgroundStangard:(NSString *)urlPhoto;
- (void)uploadProfileImageToServer:(UIImage *)primaryPhoto andCompletion:(void (^) (id responseObject))completion;
- (void)uploadBackgroundToServer:(UIImage *)primaryPhoto andCompletion:(void (^) (MFResponse *responseObject))completion;

// -------------------------------------- Baby Sleep --------------------------------------
- (void)requestAddNewBabySleep:(BabySleepModel *)babySleep andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (NSURLSessionDataTask*)requestGetListBabySleepWithId:(NSString *)babyId andNumberPage:(int)numberPage completed:(void (^) (MFRession *responseObject))completion error:(PHRResponseError)errorBlock;


// -------------------------------------- New Food API ----------------------------------------
- (void)requestAddNewFood:(FoodItem *)foodItem completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestUpdateFood:(FoodItem*)foodItem andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (NSURLSessionDataTask*)requestGetListFoodWithDuration:(NSString*)duration FoodType:(int)foodType andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDetailFoodWithId:(NSString *)foodID healthType:(NSString*)foodType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock;
- (NSURLSessionDataTask*)requestGetTimeLineFood:(NSString *)profileId withFoodType:(int)foodType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteStandardFood:(NSString *)foodID foodType:(NSString*) foodType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// -------------------------------------- New Fitness API ----------------------------------------
- (void)requestAddNewFitness:(FitnessModel *)fitnessModel completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestEditFitness:(FitnessModel *)fitnessModel completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (NSURLSessionDataTask*)requestGetListFitnessWithDuration:(NSString*)duration fitnessType:(int)fitnessType andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (NSURLSessionDataTask*)requestGetTimeLineFitness:(NSString *)profileId withFitnessType:(int)fitnessType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestDeleteStandardFitness:(NSString *)fitnessID fitnessType:(NSString*) fitnessType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestDetailFitnessWithId:(NSString *)fitnessID fitnessType:(NSString*)fitnessType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock;

// -------------------------------------- New Baby Food API ----------------------------------------

- (NSURLSessionDataTask*)requestGetListBabyFoodWithDuration:(NSString*)duration andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// -------------------------------------- New Baby Growth API --------------------------------------
- (void)requestAddNewBabyGrowth:(BabyGrowth *)babyGrowth completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestUpdateBabyGrowth:(BabyGrowth*)babyGrowth andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (NSURLSessionDataTask*)requestGetListBabyGrowthWithDuration:(NSString*)duration growthType:(int)growthType andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDetailBabyGrowthWithId:(NSString *)babyGrowthID babyGrowthType:(NSString*)babyGrowthType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock;
- (NSURLSessionDataTask*)requestGetTimeLineBabyGrowth:(NSString *)profileId withBabyGrowthType:(int)babyGrowthType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;
- (void)requestDeleteBabyGrowth:(NSString *)babyGrowthID babyGrowthType:(NSString*) babyGrowthType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

// -------------------------------------- Sync --------------------------------------
- (void)requestSynchronizeBodyMeasurement:(NSArray *)arrayBodyMeasurement profileID:(NSString*)profileID uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestSynchronizeTemperature:(NSArray *)arrayTemperature profileID:(NSString*)profileID type:(NSString*)type uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestSynchronizeStandardFood:(NSArray *)arrayStandardFood profileID:(NSString*)profileID type:(NSString*)type uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestSynchronizeStandardLifeStyle:(NSArray *)arrayLifeStype profileID:(NSString*)profileID uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestSynchronizeStandardFitness:(NSArray *)arrayFitness profileID:(NSString*)profileID type:(NSString*) type uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestSynchronizeBabyGrowth:(NSArray *)arrayBabyGrowth profileID:(NSString*)profileID type:(NSString*) type uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestActiveForSync:(NSString*)uuid profileID:(NSString*)profileID andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestValidateForSync:(NSString*)uuid profileID:(NSString*)profileID andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock;

- (void)requestActiveForSync:(NSString*)udid profileID:(NSString*)profileID;
- (void)requestValidateUDID:(NSString*)udid profileID:(NSString*)profileID;


+ (NSString*)getMasterProfileIDFromResponse:(id)responseObject;

// ------------------------------------- Movie Talk API ---------------------------------------------

@end


