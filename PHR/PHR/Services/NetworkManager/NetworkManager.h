//
//  NetworkManager.h
//  PHR
//
//  Created by DEV-MinhNN on 11/13/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "BabySleepModel.h"

@interface NetworkManager : NSObject

+ (instancetype)sharedManager;

+ (void)saveSettingFacebookAccessToken:(NSString*)token;
+ (void)saveSettingEmail:(NSString *)email;
+ (void)saveSettingPassword:(NSString *)password;
+ (void)clearSavedEmailPassword;
+ (void)clearSavedPassword;
+ (void)clearSavedFacebookAccessToken;
+ (void)clearSettingSynchronizeHealthKit;
+ (void)clearSavedDeviceToken;
+ (void)saveSettingSynchronizeHealthKit:(BOOL)isAllowRead withKey:(NSString*)key ;

- (void)processUploadImageInNewThread:(UIImage*)newImage andCompletion:(void (^) (NSString * msgError, id result))completion;

@end
