//
//  NetworkManager.m
//  PHR
//
//  Created by DEV-MinhNN on 11/13/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "NetworkManager.h"
#import "NSString+Extension.h"

@implementation NetworkManager

+ (instancetype)sharedManager {
    static NetworkManager *_sharedClient = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        _sharedClient = [[NetworkManager alloc] init];
    });
    
    return _sharedClient;
}

#pragma mark -

+ (void)saveSettingEmail:(NSString *)email {
    [NSUtils setValue:email forKey:PHRJNKeyChainEmail];
}

+ (void)saveSettingPassword:(NSString *)password {
    [NSUtils setValue:password forKey:PHRJNKeyChainPass];
}

+ (void)saveSettingFacebookAccessToken:(NSString *)token {
    //PHRAppStatus.email = email;
    [NSUtils setValue:token forKey:PHRJNKeyChainFacebookAccessToken];
}

+ (void)clearSavedEmailPassword {
    [NSUtils removeObjectForKey:PHRJNKeyChainEmail];
    [NSUtils removeObjectForKey:PHRJNKeyChainPass];
}

+ (void)clearSavedFacebookAccessToken {
    [NSUtils removeObjectForKey:PHRJNKeyChainFacebookAccessToken];
}

+ (void)clearSavedPassword {
    [NSUtils removeObjectForKey:PHRJNKeyChainPass];
}

+ (void)clearSavedDeviceToken {
  [NSUtils removeObjectForKey:KEY_APNS_REGISTER_ID];
}

+ (void)clearSettingSynchronizeHealthKit {
    [NSUtils removeObjectForKey:PHRJNKeyChainAllowSynchronizeHealthKitRead];
    [NSUtils removeObjectForKey:PHRJNKeyChainAllowSynchronizeHealthKitWrite];
    [NSUtils removeObjectForKey:PHRJNKeyChainAllowSynchronizeHealthKitBy3G];
}

+ (void)saveSleepTime:(NSString *) sleepTime {
    [NSUtils setValue:sleepTime forKey:[@(StandardHomeTypeLifeStyle) stringValue]];
}

+ (void)saveSettingSynchronizeHealthKit:(BOOL)isAllowRead withKey:(NSString*)key {
    [[NSUserDefaults standardUserDefaults] setBool:isAllowRead forKey:key];
    //[NSUtils set:@(isAllowRead) forKey:PHRJNKeyChainAllowSynchronizeHealthKitRead];
}

- (void)processUploadImageInNewThread:(UIImage *)newImage andCompletion:(void (^)(NSString *, id))completion {
//    [[PHRClient instance] uploadImageFromDeviceToServer:newImage andCompletion:^(MFResponse *responseObject) {
//        if (completion && [responseObject.status isEqualToString:KEY_SUCCESS]) {
//            completion (PHR_STR_NULL, responseObject.content);
//        }
//    }];
}

@end
