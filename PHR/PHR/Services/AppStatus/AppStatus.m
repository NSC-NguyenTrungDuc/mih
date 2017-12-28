//
//  AppStatus.m
//  PHR
//
//  Created by DEV-CongHT on 10/12/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "AppStatus.h"

@interface AppStatus() <ProfileDelegate>{
    
}
@end

@implementation AppStatus{
    
}

- (id)init{
    self = [super init];
    if (self) {
        _UDID = [UIDevice currentDevice].identifierForVendor.UUIDString;
        _arrayStandardProfile = [[NSMutableArray alloc] init];
        _arrayBabyProfile = [[NSMutableArray alloc] init];
    }
    return self;
}

- (void)setToken:(NSString *)token{
    _token = token;
    [[SDWebImageDownloader sharedDownloader] setValue:token forHTTPHeaderField:KEY_Token];
}

- (void)setCurrentStandard:(ProfileStandard *)currentStandard{
    if (_currentStandard) {
        _currentStandard.delegate = nil;
    }
    _currentStandard = currentStandard;
    if (_currentStandard) {
        _currentStandard.delegate = self;
    }
    // save last view profile
    NSUserDefaults *userDefault = [NSUserDefaults standardUserDefaults];
    [userDefault setObject:_currentStandard.profileId forKey:[self keyStandard]];
    [userDefault synchronize];
}

- (NSString*)keyStandard{
    return [NSString stringWithFormat:@"%@-last-standard", self.accountId];
}

- (NSString*)getLastViewedProfileStandardId{
    NSUserDefaults *userDefault = [NSUserDefaults standardUserDefaults];
    return [userDefault objectForKey:[self keyStandard]];
}

- (void)setCurrentBaby:(ProfileBaby *)currentBaby{
    if (_currentBaby) {
        _currentBaby.delegate = nil;
    }
    _currentBaby = currentBaby;
    if (_currentBaby) {
        _currentBaby.delegate = self;
    }
    // save last view profile
    NSUserDefaults *userDefault = [NSUserDefaults standardUserDefaults];
    [userDefault setObject:_currentBaby.profileId forKey:[self keyBaby]];
    [userDefault synchronize];
}

- (NSString*)keyBaby{
    return [NSString stringWithFormat:@"%@-last-baby", self.accountId];
}

- (NSString*)getLastViewedProfileBabyId{
    NSUserDefaults *userDefault = [NSUserDefaults standardUserDefaults];
    return [userDefault objectForKey:[self keyBaby]];
}

#pragma mark - Profile delegate
- (void)profile:(Profile *)profile updateAvatar:(NSString *)newAvatar{
    if (profile.isBaby) {
        [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyAvatarBabyChanged object:profile userInfo:nil];
    }
    else{
        [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyAvatarStandardChanged object:profile userInfo:nil];
    }
}

#pragma mark - Load data
// Clear data when log out
- (void)clearAllData{
    // Session
    self.token = nil;
    self.email = nil;
    self.accountId = nil;
    self.standardBackgroundUrl = nil;
    self.babyBackgroundUrl = nil;
    
    self.type = PHRGroupTypeStandard;
    self.isLocalStandard = NO;
    self.isLocalBaby = NO;
    
    self.totalFoodMorning = 0;
    self.totalFoodNoon = 0;
    self.totalFoodAfternoon = 0;
    
    // @luonglh must remove observe before remove object
    [self.arrayStandardProfile removeAllObjects];
    [self.arrayBabyProfile removeAllObjects];
    _currentStandard = nil;
    _currentBaby = nil;
    _masterProfileId = nil;
    _chatHistory = nil;
}

/*
 content =     (
 {
 "active_profile_flg" = 1;
 "baby_flg" = 0;
 "full_name" = luong;
 "full_name_kana" = luong;
 id = 192;
 nickname = luong;
 "picture_profile_url" = "<null>";
 }
 );
 */
- (void)parseStandardProfilesResponse:(id)response{
    [self.arrayStandardProfile removeAllObjects];
    _currentStandard = nil;
    if (!response || response[KEY_Content] == [NSNull null] || !response[KEY_Content]) {
        return;
    }
    NSString *lastViewed = [self getLastViewedProfileStandardId];
    ProfileStandard *active = nil;
    NSArray *content = response[KEY_Content];
    for (id item in content) {
      [Profile sharedManager];
        ProfileStandard *profile = [[ProfileStandard alloc] initWithDictionary:item];
        [self.arrayStandardProfile addObject:profile];
        // Check last viewed profile
        if (lastViewed && [profile.profileId isEqualToString:lastViewed]) {
            self.currentStandard = profile;
        }
        // Check profile active
        if (profile.isActive && [profile.udid isEqualToString:self.UDID]) {
            active = profile;
        }
    }
    // If not found lastview -> assign to active
    if (!self.currentStandard && active) {
        self.currentStandard = active;
    }
}

- (void)parseBabyProfilesResponse:(id)response{
    [self.arrayBabyProfile removeAllObjects];
    _currentBaby = nil;
    if (!response || response[KEY_Content] == [NSNull null] || !response[KEY_Content]) {
        return;
    }
    NSString *lastViewed = [self getLastViewedProfileBabyId];
    ProfileBaby *active = nil;
    NSArray *content = response[KEY_Content];
    for (id item in content) {
        ProfileBaby *profile = [[ProfileBaby alloc] initWithDictionary:item];
        [self.arrayBabyProfile addObject:profile];
        // Check last viewed profile
        if (lastViewed && [profile.profileId isEqualToString:lastViewed]) {
            self.currentBaby = profile;
        }
        // Check profile active
        if (profile.isActive && [profile.udid isEqualToString:self.UDID]) {
            active = profile;
        }
    }
    // If not found lastview -> assign to active
    if (!self.currentBaby && active) {
        self.currentBaby = active;
    }
}

#pragma mark - Baby profiles
- (void)addNewBabyProfile:(ProfileBaby*)baby{
    if (self.arrayBabyProfile.count <= 0){
        baby.udid = self.UDID;
        baby.isActive = YES;
    }
    [self.arrayBabyProfile addObject:baby];
    if ([baby checkActive]) {
        self.currentBaby = baby;
        [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileBabyActiveChanged object:baby userInfo:nil];
    }
}

- (void)addNewStandardProfile:(ProfileStandard*)standard{
    [self.arrayStandardProfile addObject:standard];
    if ([standard checkActive]) {
        self.currentStandard = standard;
        [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileStandardActiveChanged object:standard userInfo:nil];
    }
}

#pragma mark - Handle Master Profile (active profile)
- (void)setActiveStandardProfileId:(NSString*)activeId{
    if (!self.arrayStandardProfile || !activeId) {
        return;
    }
    for (ProfileStandard *profile in self.arrayStandardProfile) {
        if ([profile.profileId isEqualToString:activeId]) {
            profile.isActive = YES;
            profile.udid = self.UDID;
            self.currentStandard = profile;
        }
        else{
            profile.isActive = NO;
        }
    }
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileStandardActiveChanged object:self.currentStandard userInfo:nil];
}

- (void)setActiveBabyProfileId:(NSString*)activeId{
    if (!self.arrayBabyProfile || !activeId) {
        return;
    }
    for (ProfileBaby *profile in self.arrayBabyProfile) {
        if ([profile.profileId isEqualToString:activeId]) {
            profile.isActive = YES;
            profile.udid = self.UDID;
            self.currentBaby = profile;
        }
        else{
            profile.isActive = NO;
        }
    }
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileBabyActiveChanged object:self.currentBaby userInfo:nil];
}

#pragma mark - Profile list action
- (void)removeStandardProfile:(NSString *)deletedId {
    for (NSInteger i = self.arrayStandardProfile.count - 1; i >= 0; i--) {
        ProfileStandard *standard = self.arrayStandardProfile[i];
        if ([standard.profileId isEqualToString:deletedId]) {
            [self.arrayStandardProfile removeObject:standard];
            break;
        }
    }
}

- (void)removeBabyProfile:(NSString *)deletedId {
    BOOL isActive = NO;
    for (NSInteger i = self.arrayBabyProfile.count - 1; i >= 0; i--) {
        ProfileBaby *baby = self.arrayBabyProfile[i];
        if ([baby.profileId isEqualToString:deletedId]) {
            isActive = baby.isActive;
            [self.arrayBabyProfile removeObject:baby];
            break;
        }
    }
    if (isActive) {
        if (self.arrayBabyProfile.count > 0) {
            // Request new active
            [PHRAppDelegate showLoading];
            ProfileBaby *baby = self.arrayBabyProfile[0];
            [[PHRClient instance] requestSetActiveStandard:NO newId:baby.profileId completed:^(id response){
                // set UUID & active flag
                baby.udid = self.UDID;
                baby.isActive = YES;
                self.currentBaby = baby;
                [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileBabyActiveChanged object:self.currentBaby];
                [PHRAppDelegate hideLoading];
            }error:^(NSString *error){
                [PHRAppDelegate hideLoading];
            }];
        }
        else{
            PHRAppStatus.currentBaby = nil;
            [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyProfileBabyActiveChanged object:nil];
        }
    }
}

#pragma mark - Utility
// Check master to push new data to HealthKit
- (BOOL)checkCurrentStandardIsMaster{
    return [self checkCurrentStandardActive] && self.currentStandard.isMainProfile;
}

// Check view only allow add/edit/sync or not
- (BOOL)checkCurrentStandardActive {
    return self.currentStandard && (self.currentStandard.isActive && [self.currentStandard.udid isEqualToString:self.UDID]);
}

// Check view only allow add/edit/sync or not
- (BOOL)checkCurrentBabyActive {
    return self.currentBaby && (self.currentBaby.isActive && [self.currentBaby.udid isEqualToString:self.UDID]);
}



@end
