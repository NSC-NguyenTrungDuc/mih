//
//  AppStatus.h
//  PHR
//
//  Created by DEV-CongHT on 10/12/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "ProfileStandard.h"
#import "ProfileBaby.h"
#import "BackgroundSettingInfo.h"
#import "LocalStorageImage.h"
#import "EMRCacheLocal.h"
#import <Realm/Realm.h>

@interface AppStatus : NSObject {
    
}
// Constant value
@property (strong, nonatomic, readonly) NSString *UDID;

// Session
@property (strong, nonatomic) NSString *token;
@property (strong, nonatomic) NSString *email;

@property (strong, nonatomic) NSString *accountId; // Id of user, who register account to this app
@property (strong, nonatomic) NSString *standardBackgroundUrl;
@property (strong, nonatomic) NSString *babyBackgroundUrl;
@property (strong, nonatomic) NSString *masterProfileId;

@property (nonatomic) PHRGroupType type;
@property (nonatomic) BOOL isLocalStandard;
@property (nonatomic) BOOL isLocalBaby;

@property (nonatomic) int totalFoodMorning;
@property (nonatomic) int totalFoodNoon;
@property (nonatomic) int totalFoodAfternoon;

@property (strong, nonatomic) RLMRealm *globalRealm;
@property (strong, nonatomic) RLMResults <BackgroundSettingInfo*> *backgroundResult;
@property (strong, nonatomic) BackgroundSettingInfo* back;
@property (strong, nonatomic) RLMResults *backgroundImageList;
@property (strong, nonatomic) EMRCacheLocal* emrCache;

// Property
@property (strong, nonatomic) NSMutableArray *arrayStandardProfile;
@property (strong, nonatomic) NSMutableArray *arrayBabyProfile;
@property (strong, nonatomic) ProfileStandard *currentStandard;
@property (strong, nonatomic) NSString *is_fist_sync;
@property (strong, nonatomic) NSString *latest_sync_time;
@property (weak, nonatomic) ProfileBaby *currentBaby;

// This flag used to check only one alertview can show profile is actived on another device
@property (nonatomic, assign) BOOL canShowAlert;

//Chat History
@property (nonatomic, assign) NSDictionary *chatHistory;

@property (nonatomic, copy) NSString *patientId;
@property (nonatomic, copy) NSString *patientCode;
@property (nonatomic, copy) NSString *hospitalCode;
@property (nonatomic, copy) NSString *hospitalName;
@property (nonatomic, copy) NSString *locate;
@property (nonatomic, copy) NSString *doctorCode;

- (void)addNewBabyProfile:(ProfileBaby*)baby;
- (void)addNewStandardProfile:(ProfileStandard*)standard;
- (void)removeStandardProfile:(NSString *)deletedId;
- (void)removeBabyProfile:(NSString *)deletedId;
- (void)setActiveStandardProfileId:(NSString*)activeId;
- (void)setActiveBabyProfileId:(NSString*)activeId;
// Parse data
- (void)parseStandardProfilesResponse:(id)response;
- (void)parseBabyProfilesResponse:(id)response;

- (void)clearAllData;
- (BOOL)checkCurrentStandardIsMaster;
// Check view only allow add/edit/sync or not
- (BOOL)checkCurrentStandardActive;
- (BOOL)checkCurrentBabyActive;

@end

