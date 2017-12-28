//
//  PHRClient.m
//  PHR
//
//  Created by Luong Le Hoang on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRClient.h"
#import "NSString+Extension.h"

#ifndef kBaseUrl
//#define kBaseUrl @"API_Host_Dev"
#define kBaseUrl @"API_Host"
#endif

@interface PHRClient(){
  
}

@end


@implementation PHRClient

#pragma mark - Share Instance
// Share Instance
+ (instancetype)instance {
  static PHRClient *_sharedClient = nil;
  static dispatch_once_t onceToken;
  dispatch_once(&onceToken, ^{
    NSString *host = [[NSBundle mainBundle] objectForInfoDictionaryKey:kBaseUrl];
    _sharedClient = [[PHRClient alloc] initWithBaseURL:[NSURL URLWithString:host]];
    [_sharedClient.requestSerializer setValue:@"application/json" forHTTPHeaderField:@"Accept"];
    [_sharedClient.requestSerializer setValue:@"application/json" forHTTPHeaderField:@"Content-Type"];
    _sharedClient.requestSerializer = [AFJSONRequestSerializer serializer];
    //_sharedClient.responseSerializer = [AFJSONResponseSerializer serializer];
    DLog(@"API: %@", host);
    [_sharedClient.reachabilityManager setReachabilityStatusChangeBlock:^(AFNetworkReachabilityStatus status){
      DLog(@"Reachability Status Changed -> %ld", (long)status);
      [PHRAppDelegate hideLoading];
    }];
    // Check ssl
    if ([host rangeOfString:@"https"].location != NSNotFound) {
      _sharedClient.securityPolicy = [AFSecurityPolicy defaultPolicy];
      _sharedClient.securityPolicy.allowInvalidCertificates = YES;
      _sharedClient.requestSerializer.timeoutInterval = 30;
    }
    _sharedClient.requestSerializer.timeoutInterval = 30;
  });
  return _sharedClient;
}

#pragma mark - Utils
// Parse token from server
- (void)getTokenFromResponseObject:(id)response {
  // Get 'token'
  if (response && response[KEY_Content] != [NSNull null] && response[KEY_Content][KEY_Token] != [NSNull null]) {
    NSString *token = response[KEY_Content][KEY_Token];
    PHRAppStatus.token = token;
    
    // Add token to header
    [self.requestSerializer setValue:PHRAppStatus.token forHTTPHeaderField:KEY_Token];
  }
  
  // get dashboard info
  [self getDashboardInfo:response];
}

- (void)getDashboardInfo:(id)response {
  if (!response || response[KEY_Content] == [NSNull null]) {
    return;
  }
  // Get standard profile & background
  PHRAppStatus.isLocalStandard = YES;
  if (response[KEY_Content][KEY_StandardBackgroundUrl] != [NSNull null]) {
    PHRAppStatus.standardBackgroundUrl = response[KEY_Content][KEY_StandardBackgroundUrl];
    PHRAppStatus.isLocalStandard = NO;
  }
  else {
    PHRAppStatus.standardBackgroundUrl = @"standard_bg";
  }
  //    if (response[KEY_Content][KEY_StandardProfileId] != [NSNull null]) {
  //        PHRAppStatus.standardProfileId = response[KEY_Content][KEY_StandardProfileId];
  //    }
  
  // Get baby profile & background
  PHRAppStatus.isLocalBaby = YES;
  if (response[KEY_Content][KEY_BabyBackgroundUrl] != [NSNull null]) {
    PHRAppStatus.babyBackgroundUrl = response[KEY_Content][KEY_BabyBackgroundUrl];
    PHRAppStatus.isLocalBaby = NO;
  }
  else {
    PHRAppStatus.babyBackgroundUrl = @"BG_Children";
  }
  //    if (response[KEY_Content][KEY_BabyProfileId] != [NSNull null]) {
  //        PHRAppStatus.babyProfileId = response[KEY_Content][KEY_BabyProfileId];
  //    }
}

/*
 Status from response
 - YES : success
 - NO  : fail
 */
+ (BOOL)getStatusFromResponse:(id)responseObject {
  if (responseObject && responseObject[KEY_Status] != [NSNull null]) {
    return [responseObject[KEY_Status] isEqualToString:KEY_SUCCESS];
  }
  return NO;
}



/*
 Get response Message, as key of localized string
 */
+ (NSString*)getMessageFromResponse:(id)responseObject {
  if (responseObject && responseObject[KEY_Message] && responseObject[KEY_Message] != [NSNull null]) {
    return responseObject[KEY_Message];
  }
  return nil;
}

+ (NSString*)getTypeFromResponse:(id)responseObject {
  if (responseObject && responseObject[KEY_Content] != [NSNull null]) {
    return [NSString stringWithFormat:@"%@",(responseObject[KEY_Content])[KEY_Type]];
  }
  return nil;
}

/*
 Get account Id
 */
+ (NSString*)getAccountIDFromResponse:(id)responseObject {
  if (responseObject && responseObject[KEY_Content] != [NSNull null]) {
    return [NSString stringWithFormat:@"%@",(responseObject[KEY_Content])[KEY_ID]];
  }
  return nil;
}

+ (NSString*)getMasterProfileIDFromResponse:(id)responseObject {
  if (responseObject && responseObject[KEY_Content] != [NSNull null]) {
    return [NSString stringWithFormat:@"%@",(responseObject[KEY_Content])[@"master_profile_id"]];
  }
  return nil;
}

+ (NSString*)getLoginTypeFromResponse:(id)responseObject {
  if (responseObject && responseObject[KEY_Content] != [NSNull null]) {
    return [NSString stringWithFormat:@"%@",(responseObject[KEY_Content])[KEY_LoginType]];
  }
  return nil;
}

+ (NSString*)getProfileStatusFromResponse:(id)responseObject {
  if (responseObject && responseObject[KEY_Content] != [NSNull null]) {
    return [NSString stringWithFormat:@"%@",(responseObject[KEY_Content])[KEY_Status]];
  }
  return nil;
}


- (void)handleResponse:(id)response completed:(PHRResponseSuccess)success error:(PHRResponseError)error {
  if ([PHRClient getStatusFromResponse:response]) {
    if (success) {
      success(response);
    }
  } else{
    NSString *message = [PHRClient getMessageFromResponse:response];
    if (error) {
      error(message);
    }
  }
}

- (void)handleErrorResponse:(NSError*)error callback:(PHRResponseError)callback {
  //    [NSUtils showMessage:kLocalizedString(kCommonRequestFail) withTitle:APP_NAME];
  if (callback) {
    callback(error.localizedDescription);
  }
}

/*
 Because Resquest using JSON serilization
 -> create http request this way
 */
- (NSString*)generateApi:(NSString*)api withParams:(NSDictionary*)params {
  NSString *url = [NSString stringWithFormat:@"%@?", api];
  if (params) {
    for (NSInteger i = 0; i < params.allKeys.count; i++) {
      NSString *key = params.allKeys[i];
      NSString *format = (i < (params.allKeys.count - 1)) ? @"%@=%@&" : @"%@=%@";
      url = [url stringByAppendingString:[NSString stringWithFormat:format, key, params[key]]];
    }
  }
  return url;
}

#pragma mark - Check internet connection
- (BOOL)checkInternetConnection{
  DLog(@"checkInternetConnection");
  if (PHRAppDelegate.networkStatus == NotReachable) {
    // Hide loading
    [PHRAppDelegate hideLoading];
    // not online
    [NSUtils showMessage:kLocalizedString(@"Internet connection seems to be offline") withTitle:APP_NAME];
  }
  return PHRAppDelegate.networkStatus != NotReachable;
}

#pragma mark - Account Flow
// Account Flow (Register & Login)

// >> Request register account
- (void)requestRegisterWithProfile:(Profile*)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (![self checkInternetConnection]) {
    return;
  }
#if DEBUG
  NSAssert((profile && profile.email && profile.name && profile.birthday), @"Parameters must be not null!!!");
#endif
  if (!profile || !profile.email || !profile.name || !profile.birthday) {
    return;
  }
  // Packaging
  NSMutableDictionary *dictProfile = [[NSMutableDictionary alloc] init];
  [dictProfile setObject:profile.name forKey:KEY_FullName];
  [dictProfile setObject:[profile stringBirthdayParam] forKey:KEY_Birthday];
  [dictProfile setObject:[profile stringGenderParam] forKey:KEY_Gender];
  [dictProfile setObject:(profile.nameKana ? profile.nameKana : @"") forKey:KEY_FullNameKana];
  [dictProfile setObject:@1 forKey:KEY_FamilyMemberType];
  [dictProfile setObject:@0 forKey:KEY_BabyFlag];
  [dictProfile setObject:@"Personal" forKey:KEY_Relationship];
  

  // Params
  NSDictionary *params = @{KEY_Email : profile.email,
                           KEY_Profile : dictProfile};
  
  NSString *udid = PHRAppStatus.UDID;
  [self POST:[NSString stringWithFormat:@"%@?udid=%@", API_Register, udid] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Hanlde response
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    // [self handleErrorResponse:error callback:errorBlock];
    if (errorBlock) {
      errorBlock(error.description);
    }
  }];
}

/*
 Request Register with facebook
 */
- (void)requestRegisterWithFaceBook:(FacebookProfile*)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (![self checkInternetConnection]) {
    return;
  }
#if DEBUG
  NSAssert((profile && profile.email && profile.name && profile.birthday), @"Parameters must be not null!!!");
#endif
  if (!profile || !profile.email || !profile.name || !profile.birthday || !profile.gender || !profile.token || !profile.facebookID) {
    return;
  }
  NSString *strDeviceToken;
  if ([NSUtils valueForKey:KEY_APNS_REGISTER_ID]) {
    strDeviceToken = [NSUtils valueForKey:KEY_APNS_REGISTER_ID];
  } else {
    strDeviceToken = @"";
  }
  NSDictionary *params = @{KEY_AccessToken : profile.token,
                           KEY_DEVICE_TOKEN: strDeviceToken,
                           KEY_FacebookId : profile.facebookID,
                           KEY_Email : profile.email,
                           KEY_Name : profile.name,
                           KEY_Birthday : [profile stringBirthdayParam],
                           KEY_Gender : [profile stringGenderParam],
                           KEY_ProfileImageURL : profile.profileImageURL,
                           };
  DLog(@"requestRegisterWithFacebook: \n%@", params);
  NSString *udid = PHRAppStatus.UDID;
  [self POST:[NSString stringWithFormat:@"%@?udid=%@", API_Register_Facebook, udid] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    if ([PHRClient getStatusFromResponse:responseObject]) {
      PHRAppStatus.email = profile.email;
      // Hanlde response
      [self getTokenFromResponseObject:responseObject];
      [self.requestSerializer setValue:PHRAppStatus.token forHTTPHeaderField:KEY_Token];
      [self handleResponse:responseObject completed:successBlock error:errorBlock];
    }
    else{
      NSString *message = [PHRClient getMessageFromResponse:responseObject];
      errorBlock(message);
    }
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    DLog(@"%@",error);
    /// error.description
    [NSUtils showMessage:kLocalizedString(@"register.fail") withTitle:APP_NAME];
    if (errorBlock) {
      errorBlock(error.description);
    }
  }];
}

/*
 Request Login
 */
- (void)requestLoginWithEmail:(NSString*)email password:(NSString*)pass completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (![self checkInternetConnection]) {
    return;
  }
#if DEBUG
  NSAssert(email != nil, @"email must be not null");
#else
  if (!email || [email isEqualToString:@""]) {
    return;
  }
#endif
  NSString *strDeviceToken;
  if ([NSUtils valueForKey:KEY_APNS_REGISTER_ID]) {
    strDeviceToken = [NSUtils valueForKey:KEY_APNS_REGISTER_ID];
  } else {
    strDeviceToken = @"";
  }
  NSDictionary *params = @{KEY_Email : email,
                           KEY_DEVICE_TOKEN: strDeviceToken,
                           KEY_Password : pass,
                           KEY_Udid : PHRAppStatus.UDID};
  DLog(@"requestLoginWithEmail: \n%@", params);
  [self POST:API_Login parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    PHRAppStatus.email = email;
    // Get Token
    [self getTokenFromResponseObject:responseObject];
    [self.requestSerializer setValue:PHRAppStatus.token forHTTPHeaderField:KEY_Token];
    
    // Hanlde response
    // @LuongLH NOTE: call successBlock because must change password for first login after register
    if (successBlock) {
      successBlock(responseObject);
    }
    
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [NSUtils showMessage:kLocalizedString(kLoginFail) withTitle:APP_NAME];
    if (errorBlock) {
      errorBlock(error.description);
    }
  }];
}

/*
 Request Login with facebook
 */
- (void)requestLoginWithFacebook:(NSString*)token completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (![self checkInternetConnection]) {
    return;
  }
#if DEBUG
  NSAssert(token != nil, @"token must be not null");
#else
  if (!token || [token isEqualToString:@""]) {
    return;
  }
#endif
  NSString *strDeviceToken;
  if ([NSUtils valueForKey:KEY_APNS_REGISTER_ID]) {
    strDeviceToken = [NSUtils valueForKey:KEY_APNS_REGISTER_ID];
  } else {
    strDeviceToken = @"";
  }
  NSDictionary *params = @{KEY_AccessToken : token,
                           KEY_DEVICE_TOKEN: strDeviceToken,
                           KEY_Udid : PHRAppStatus.UDID};
  DLog(@"requestLoginWithFacebook: \n%@", params);
  [self POST:API_Login_Facebook parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    if ([PHRClient getStatusFromResponse:responseObject]) {
      //Get Email
      if (responseObject && responseObject[KEY_Content] != [NSNull null] && responseObject[KEY_Content][KEY_Email] != [NSNull null]) {
        NSString *email = responseObject[KEY_Content][KEY_Email];
        PHRAppStatus.email = email;
      }
      // Get Token
      [self getTokenFromResponseObject:responseObject];
      [self.requestSerializer setValue:PHRAppStatus.token forHTTPHeaderField:KEY_Token];
      successBlock(responseObject);
    } else{
      NSString *message = [PHRClient getMessageFromResponse:responseObject];
      errorBlock(message);
    }
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    NSLog(@"%@",error);
    // [NSUtils showMessage:kLocalizedString(kLoginFail) withTitle:APP_NAME];
    if (errorBlock) {
      errorBlock(error.description);
    }
  }];
}

/*
 Request Change Agreement Status
 */
- (void)requestChangeAgreementStatus:(NSString*)accountID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
#if DEBUG
  NSAssert(accountID != nil, @"accountID must be not null");
#else
  if (!accountID || [accountID isEqualToString:@""]) {
    return;
  }
#endif
  
  [self PUT:[NSString stringWithFormat: API_ChangeStatusAgreement, accountID] parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    
    successBlock(responseObject);
    
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    NSLog(@"%@",error);
    // [NSUtils showMessage:kLocalizedString(kLoginFail) withTitle:APP_NAME];
    if (errorBlock) {
      errorBlock(error.description);
    }
  }];
}

/*
 Example:
 URL:http://localhost:8080/api/accounts/change_password
 
 Header Param:
 - token: DgRgmle-eakU6on8N2trDHDZ_ARiVIwso685KXYPUKZY0A37pJ1Uk2LoH8NzxbecRVW2Tdb0yZhJy3hF8yUxaw
 
 Body Param:
 {
 "email":"oai.dang.van@nextop.asia",
 "password":"hl6lpzpz",
 "new_password":"123456"
 }
 */
/*
 Request change password
 */
- (void)requestChangePassword:(NSString*)oldPass toNewPassword:(NSString*)newPass completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!PHRAppStatus.token || !oldPass || !newPass) {
    return;
  }
  NSString *strDeviceToken;
  if ([NSUtils valueForKey:KEY_APNS_REGISTER_ID]) {
    strDeviceToken = [NSUtils valueForKey:KEY_APNS_REGISTER_ID];
  } else {
    strDeviceToken = @"";
  }
  NSDictionary *params = @{KEY_Email : PHRAppStatus.email,
                           KEY_DEVICE_TOKEN: strDeviceToken,
                           KEY_Password: oldPass,
                           KEY_NewPassword : newPass,};
  [self PUT:API_ChangePassword parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Get Token
    [self getTokenFromResponseObject:responseObject];
    // Update token to header
    [self.requestSerializer setValue:PHRAppStatus.token forHTTPHeaderField:KEY_Token];
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
    
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

/*
 Send request reset password
 */
- (void)requestResetPasswordForEmail:(NSString*)email completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!email || [email isEmpty]) {
    return;
  }
  [self POST:API_ForgotPassword parameters:@{KEY_Email : email} success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

/*
 LOGOUT
 */
- (void)requestLogoutwithCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  
  [self PUT:API_Logout parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}
//- (void)requestLogoutWithCompleted:(void (^) (MFResponse *responseObject))completion {
//  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty]) {
//    NSError *error = nil;
//    MFResponse *response = [MFResponse responseObjectWithRequestOperation:nil error:error];
//    if (completion) {
//      completion(response);
//    }
//  }
//  [self PUT:API_Logout parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
//    NSDictionary *json = (NSDictionary *)responseObject;
//    MFResponse *response = [MFResponse responseObjectWithRequestOperation:json error:nil];
//    if (completion) {
//      completion(response);
//    }
//  } failure:^(NSURLSessionDataTask *task, NSError *error) {
//    MFResponse *response = [MFResponse responseObjectWithRequestOperation:nil error:error];
//    if (completion) {
//      completion(response);
//    }
//  }];
//}

#pragma mark - Profile Standard
// ------------------------ Profile Standard -----------------------------
/*
 Standard profile LIST
 * type: ~ isBaby -> 0: standard, 1: baby
 */
- (void)requestProfileList:(int)type completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!PHRAppStatus.token) {
    return;
  }
  NSDictionary *params = @{KEY_BabyFlag : [NSString stringWithFormat:@"%d", (int)type]};
  NSString *api = [self generateApi:API_FamilyList withParams:params];
  //    self.requestSerializer = [AFHTTPRequestSerializer serializer];
  //    [self.requestSerializer setValue:PHRAppStatus.token forHTTPHeaderField:KEY_Token];
  [self GET:api parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
    
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
  //    self.requestSerializer = [AFHTTPRequestSerializer serializer];
}

- (void)requestStandardProfileListCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self requestProfileList:0 completed:successBlock error:errorBlock];
}

// ----- Standard ------
/*
 Detail PROFILE
 */
- (void)requestGetDetailStandardProfileId:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSString *detailURL = [NSString stringWithFormat:@"%@/%@", API_StandardProfile, profileId];
  [self GET:detailURL parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject){
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error){
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

/*
 Delete PROFILE
 */
- (void)requestDeleteStandardProfileId:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self DELETE:[NSString stringWithFormat:@"%@/%@", API_StandardProfile, profileId]  parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

/*
 Add new PROFILE
 */
- (void)requestAddNewStandardProfile:(ProfileStandard *)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!profile || !profile.name) {
    return;
  }
  NSDictionary *params = [self paramsFromStandardProfile:profile];
  DLog(@"Profile: \n %@", params);
  [self POST:API_StandardProfile parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", task.originalRequest);
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

/*
 Edit PROFILE
 */
- (void)requestEditStandardProfile:(ProfileStandard *)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!profile || !profile.name) {
    return;
  }
  NSDictionary *params = [self paramsFromStandardProfile:profile];
  [self PUT:[NSString stringWithFormat:@"%@/%@", API_StandardProfile, profile.profileId] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

- (NSDictionary*)paramsFromStandardProfile:(ProfileStandard*)profile {
  NSMutableDictionary *dict = [NSMutableDictionary dictionaryWithDictionary:@{KEY_FullName : profile.name,
                                                                              KEY_FullNameKana : profile.nameKana ? profile.nameKana : @"",
                                                                              KEY_Gender : [profile stringGenderParam],
                                                                              KEY_ZipCode : profile.zipCode ? profile.zipCode : @"",
                                                                              KEY_City : profile.city ? profile.city : @"",
                                                                              KEY_Address : profile.address ? profile.address : @"",
                                                                              KEY_Relationship : profile.relationship ? profile.relationship : @"",
                                                                              KEY_Occupation : profile.occupation ? profile.occupation : @"",
                                                                              KEY_Prefecture : profile.prefecture ? profile.prefecture : @"",
                                                                              }];
  if (profile.birthday) {
    [dict setObject:[profile stringBirthdayParam] forKey:KEY_Birthday];
  }
  if (profile.profileId) {
    [dict setObject:profile.profileId forKey:KEY_AccountId];
  }
  if (profile.avatar) {
    [dict setObject:profile.avatar forKey:KEY_PictureProfileUrl];
  }
  return dict;
}

- (void)requestSetActiveStandard:(BOOL)isStandard newId:(NSString *)newId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!newId) {
    return;
  }
  NSString *url =  [NSString stringWithFormat:API_ProfileSetActive, newId, isStandard ? @"0":@"1" ,PHRAppStatus.UDID];
  [self PUT:url parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}



#pragma mark - clinic

- (void)requestSearchHospitalWithName:(NSString*)name address:(NSString*)address tel:(NSString*)tel country:(NSString*)country completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSMutableDictionary *params = [NSMutableDictionary new];
  if (name && ![name isEqualToString:@""]) {
    params[@"hosp_name"] = name;
  }
  if (address && ![address isEqualToString:@""]) {
    params[@"address"] = address;
  }
  if (tel && ![tel isEqualToString:@""]) {
    params[@"tel"] = tel;
  }
  if (country && ![country isEqualToString:@""]) {
    params[@"country_code"] = country;
  }
  NSString *api = [self generateApi:API_SearchHospital withParams:params];
  NSString *encoded = [api stringByAddingPercentEscapesUsingEncoding:NSUTF8StringEncoding];
  
  [self GET:encoded parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
    
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

- (void)requestAddClinicAccountName:(NSString*)name hospCode:(NSString*)code pass:(NSString*)pass profileId:(NSString*)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  NSDictionary *params = @{@"username" : name,
                           @"hosp_code" : code,
                           @"password" : pass};
  DLog(@"Profile: \n %@", params);
  [self POST:[NSString stringWithFormat:API_ClinicAdd, profileId] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", task.originalRequest);
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

- (void)requestDeleteClinicAccount:(NSString*)clinicId profileId:(NSString*)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  [self DELETE:[NSString stringWithFormat:API_ClinicDelete, profileId, clinicId]  parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

- (void)requestSetActiveClinicAccount:(NSString*)clinicId profileId:(NSString*)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  NSString *url = [NSString stringWithFormat:API_ClinicSetActive, profileId, clinicId];
  [self PUT:url parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

#pragma mark - Profile Baby
// ------------------------ Profile Baby -----------------------------

- (NSDictionary*)paramsFromBabyProfile:(ProfileBaby*)profile forAddNew:(Boolean)new{
  NSLog(@"%@",profile.birthday);
  if(new){
    NSMutableDictionary *dict = [NSMutableDictionary dictionaryWithDictionary:@{//KEY_PictureProfileUrl : profile.avatar
                                                                                KEY_FullName : profile.name ? profile.name : @"",
                                                                                KEY_FullNameKana : profile.nameKana ? profile.nameKana : @"",
                                                                                KEY_NickName : profile.nickName ? profile.nickName : @"",
                                                                                KEY_Birthday : profile.birthday ? profile.birthday : @"",
                                                                                KEY_Gender : [profile stringGenderParam],
                                                                                KEY_Relationship : profile.relationship ? profile.relationship : @"",
                                                                                
                                                                                KEY_BabyGrowthHeightMode : @{
                                                                                    KEY_Height : profile.growth && profile.growth.height ? profile.growth.height : @"",
                                                                                    KEY_DoctorNote : @"",
                                                                                    KEY_ParentNote : @"",
                                                                                    KEY_MedicalRecordUrl : @""
                                                                                    },
                                                                                
                                                                                KEY_BabyGrowthWeightMode : @{
                                                                                    KEY_Weight : profile.growth && profile.growth.weight ? profile.growth.weight : @"",
                                                                                    KEY_DoctorNote : @"",
                                                                                    KEY_ParentNote : @"",
                                                                                    KEY_MedicalRecordUrl : @""
                                                                                    }
                                                                                }];
    if (profile.avatar) {
      [dict setObject:profile.avatar forKey:KEY_PictureProfileUrl];
    }
    if (profile.birthday) {
      [dict setObject:[profile stringBirthdayParam] forKey:KEY_Birthday];
    }
    return dict;
  }else{
    NSMutableDictionary *dict = [NSMutableDictionary dictionaryWithDictionary:@{//KEY_PictureProfileUrl : profile.avatar
                                                                                KEY_FullName : profile.name ? profile.name : @"",
                                                                                KEY_FullNameKana : profile.nameKana ? profile.nameKana : @"",
                                                                                KEY_NickName : profile.nickName ? profile.nickName : @"",
                                                                                KEY_Birthday : profile.birthday ? profile.birthday : @"",
                                                                                KEY_Gender : [profile stringGenderParam],
                                                                                KEY_Relationship : profile.relationship ? profile.relationship : @"",
                                                                                KEY_BabyGrowthHeightMode : @{
                                                                                    KEY_GrowthID: profile.growth.growthId ? profile.growth.growthId : @"",
                                                                                    KEY_Height : profile.growth && profile.growth.height ? profile.growth.height : 0,
                                                                                    KEY_DoctorNote : profile.growth.doctorNote ? profile.growth.doctorNote : @"",
                                                                                    KEY_ParentNote : profile.growth.parentNote ? profile.growth.parentNote : @"",
                                                                                    KEY_MedicalRecordUrl : profile.growth.medicalRecordUrl ? profile.growth.medicalRecordUrl : @""
                                                                                    },
                                                                                
                                                                                KEY_BabyGrowthWeightMode : @{
                                                                                    KEY_GrowthID: profile.growth.growthWeightId ? profile.growth.growthWeightId : @"",
                                                                                    KEY_Weight : profile.growth && profile.growth.weight ? profile.growth.weight : 0,
                                                                                    KEY_DoctorNote : profile.growth.doctorNote ? profile.growth.doctorNote : @"",
                                                                                    KEY_ParentNote : profile.growth.parentNote ? profile.growth.parentNote : @"",
                                                                                    KEY_MedicalRecordUrl : profile.growth.medicalRecordUrl ? profile.growth.medicalRecordUrl : @""
                                                                                    }
                                                                                }];
    if (profile.avatar) {
      [dict setObject:profile.avatar forKey:KEY_PictureProfileUrl];
    }
    if (profile.birthday) {
      [dict setObject:[profile stringBirthdayParam] forKey:KEY_Birthday];
    }
    return dict;
    
  }
}

- (void)requestBabyProfileListCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self requestProfileList:1 completed:successBlock error:errorBlock];
}

- (void)requestAddNewBabyProfile:(ProfileBaby*)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!profile || !profile.name) {
    return;
  }
  NSDictionary *params = [self paramsFromBabyProfile:profile forAddNew:YES];
  DLog(@"ProfileBody:%@",params);
  [self POST:[NSString stringWithFormat:@"%@?udid=%@", API_BabyProfile, PHRAppStatus.UDID] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

/*
 Delete Baby profile
 */
- (void)requestDeleteBabyProfileId:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSMutableDictionary *dictProfile = [[NSMutableDictionary alloc] init];
  [dictProfile setObject:PHRAppStatus.UDID forKey:KEY_Udid];
  [self DELETE:[NSString stringWithFormat:@"%@/%@", API_BabyProfile, profileId]  parameters:dictProfile success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

/*
 Detail baby profile
 */
- (void)requestGetDetailBabyProfileId:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSString *detailURL = [NSString stringWithFormat:@"%@/%@", API_BabyProfile, profileId];
  [self GET:detailURL parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject){
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error){
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

/*
 Edit baby profile
 */
- (void)requestEditBabyProfile:(ProfileBaby *)profile completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!profile || !profile.name) {
    return;
  }
  NSDictionary *params = [self paramsFromBabyProfile:profile forAddNew:NO];
  DLog(@"why: %@ and param: %@",[NSString stringWithFormat:@"%@/%@", API_BabyProfile, profile.profileId],params);
  [self PUT:[NSString stringWithFormat:@"%@/%@", API_BabyProfile, profile.profileId] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}


#pragma mark - Standard Home
// ----------------- Standard Home ------------------
/*
 HOME PAGE
 {
 content =     {
 "account_id" = 212;
 "active_profile_flg" = 1;
 "baby_flg" = 0;
 bmi = "0.08";
 "full_name" = 123;
 "full_name_kana" = 123;
 id = 363;
 kcal = "<null>";
 nickname = 123;
 "picture_profile_url" = "<null>";
 quantity = 0;
 temperature = "36.7";
 "time_sleep" = "<null>";
 unit = C;
 };
 message = "message.success";
 status = SUCCESS;
 }
 */
- (void)requestGetHomePageStandard:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self GET:[NSString stringWithFormat:API_StandardHomePage, profileId] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSLog(@"%@",responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}


#pragma mark - Standard Health
/*
 http://localhost:8080/api/profiles/60/standard_health
 {
 "datetime_record" : "2015-10-13T10:29:14.000+0000",
 "height" : 2,
 "weight" : 95,
 "waist_line" : null,
 "chest_size" : "3",
 "low_blood_press" : "100",
 "high_blood_press" : "150",
 "note" : "notto"
 }
 */
/*
 Health Add New
 */

//New API

- (void)requestDeleteStandardHealth:(NSString *)healthId healthType:(NSString*) healthType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  
  NSLog(@"%@",[NSString stringWithFormat:API_StandardHealthDelete, PHRAppStatus.currentStandard.profileId,healthType, healthId]);
  [self DELETE:[NSString stringWithFormat:API_StandardHealthDelete, PHRAppStatus.currentStandard.profileId,healthType, healthId] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSString *status = responseObject[KEY_Status];
    DLog(@"%@", responseObject);
    if (successBlock && [status isEqualToString:KEY_SUCCESS]) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}


//New API
- (NSURLSessionDataTask*)requestGetListStandardHealthWithTypeAndDuration:(NSString *)profileId withHealthType:(int)healthType andDuration:(NSString*)duration completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock
{
  //API_StandardHealthGetList
  if(healthType == ChartContentTypeBodyFat) {
    healthType  = ChartContentTypeBMI;
  } else if (healthType == ChartContentTypeBMI) {
    healthType  = ChartContentTypeBodyFat;
  }
  NSString *type = [NSString stringWithFormat:@"0%d",healthType + 1];
  return [self GET:[NSString stringWithFormat:API_StandardHealtGetListWithDuration, profileId, type,duration] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    if (successBlock) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

//New API
- (NSURLSessionDataTask*)requestGetTimeLineBodyMeasurement:(NSString *)profileId withHealthType:(int)healthType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock
{
  //API_StandardHealthGetList
  if(healthType == ChartContentTypeBodyFat) {
    healthType  = ChartContentTypeBMI;
  } else if (healthType == ChartContentTypeBMI) {
    healthType  = ChartContentTypeBodyFat;
  }
  NSString *type = [NSString stringWithFormat:@"0%d",healthType + 1];
  NSLog(@"%@",[NSString stringWithFormat:API_StandardHealtGetListTimeLine, profileId, type,pageNumber]);
  NSURLSessionDataTask *request = [self GET:[NSString stringWithFormat:API_StandardHealtGetListTimeLine, profileId, type,pageNumber] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
    
  }];
  return request;
}


//New Request detail body measurement API
- (void)requestDetailBodyMeasurementWithId:(NSString *)healthId healthType:(NSString*)healthType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock {
  
  [self GET:[NSString stringWithFormat:API_StandardHealtGetDetail, PHRAppStatus.currentStandard.profileId,healthType, healthId] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    if (successBlock) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

//New Update API
- (void)requestUpdateBodyMeasurement:(BodyMeasurementModel*)bodyItem andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{KEY_DateRecord : bodyItem.date,
                           KEY_Height : bodyItem.height ? bodyItem.height : @"",
                           KEY_Weight : bodyItem.weight ? bodyItem.weight : @"",
                           KEY_PercentageFat : bodyItem.percentFat ? bodyItem.percentFat : @"",
                           KEY_BMI : bodyItem.bmi  ? bodyItem.bmi : @"",
                           KEY_Note : bodyItem.note ? bodyItem.note : @"",};
  if(bodyItem.type == BodyMeasurementTypeBodyFat) {
    bodyItem.type  = ChartContentTypeBMI;
  } else if (bodyItem.type == BodyMeasurementTypeBMI) {
    bodyItem.type  = ChartContentTypeBodyFat;
  }
  NSString *type = [NSString stringWithFormat:@"0%d",bodyItem.type + 1];
  NSLog(@"%@",[NSString stringWithFormat:API_StandardHealthEdit,PHRAppStatus.currentStandard.profileId,type, bodyItem.bodyMeasurementID]);
  [self PUT:[NSString stringWithFormat:API_StandardHealthEdit,PHRAppStatus.currentStandard.profileId,type, bodyItem.bodyMeasurementID] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    if (successBlock) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
  
}



#pragma mark - Standard And Baby Medicine

- (NSURLSessionDataTask*)requestMedicinesWithApiID:(NSString *)apiId andNumberPage:(int)numberPage andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSLog(@"%@",[NSString stringWithFormat:API_StandardMedicines, apiId, numberPage]);
  return [self GET:[NSString stringWithFormat:API_StandardMedicines, apiId, numberPage] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    if (successBlock) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestDrugsWithApiID:(NSString *)apiId andPrescriptionId:(NSString *)presId andNumberPage:(int)numberPage andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self GET:[NSString stringWithFormat:API_Prescription, apiId,presId, numberPage] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    if (successBlock) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestAddNewMedicineWithObjNote:(BabyMedicineModel *)medicineNote
                            andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_MedicineNote_Time      : medicineNote.time_take_medicine,
                           KEY_MedicineNote_Name      : medicineNote.name,
                           KEY_MedicineNote_Method    : medicineNote.method,
                           KEY_MedicineNote_Quantity  : medicineNote.quantity,
                           KEY_MedicineNote_Unit      : medicineNote.unit,
                           KEY_MedicineNote_Pre_URL   : medicineNote.prescription_url,
                           KEY_MedicineNote_Dose      : medicineNote.dose,
                           KEY_Note                   : medicineNote.note
                           };
  [self POST:[NSString stringWithFormat:API_AddNewMedicineNote, @""] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    if (successBlock) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestAddNewPrescription:(NSString *)prescriptionID andPres:(NSString *)prescriptionName andDate:(NSString*)date withArrayImages:(NSArray*)arrayImages completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty]) {
    return;
  }
  NSDictionary *params;
  
  NSError *error;
  NSData *jsonData = [NSJSONSerialization dataWithJSONObject:arrayImages options:NSJSONWritingPrettyPrinted error:&error];
  NSString *jsonStringURL = [[NSString alloc] initWithData:jsonData encoding:NSUTF8StringEncoding];
  
  if (prescriptionID == nil) {
    params = @{
               KEY_Prescription_URL : jsonStringURL,
               KEY_DateRecord : date,
               KEY_Prescription_Name : prescriptionName,
               KEY_Source : @"api_add_new",
               KEY_Prescription_ID: @""};
  } else {
    params = @{
               KEY_Prescription_URL : jsonStringURL,
               KEY_DateRecord : date,
               KEY_Prescription_Name : prescriptionName,
               KEY_Source : @"api_update",
               KEY_Prescription_ID: prescriptionID};
  }
  DLog(@"%@", params);
  [self POST:[NSString stringWithFormat:API_AddNewMedicineNote, PHRAppStatus.currentBaby.profileId] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

- (void)requestAddNewDrug:(NSDictionary *)params andPresID:(NSString *)presID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty]) {
    return;
  }
  
  [self POST:[NSString stringWithFormat:API_NewDrug, PHRAppStatus.currentBaby.profileId,presID] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
  
}


- (void)requestUpdateDrug:(NSDictionary *)params andPresID:(NSString *)presID andDrugID:(NSString *)drugID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty]) {
    return;
  }
  
  DLog(@"%@",[NSString stringWithFormat:API_UpdateDrug, PHRAppStatus.currentBaby.profileId,presID,drugID]);
  
  [self PUT:[NSString stringWithFormat:API_UpdateDrug, PHRAppStatus.currentBaby.profileId,presID,drugID] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
  
}

- (void)requestDeleteDrug:(NSString *)presID andDrugID:(NSString *)drugID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty]) {
    return;
  }
  
  DLog(@"%@",[NSString stringWithFormat:API_UpdateDrug, PHRAppStatus.currentBaby.profileId,presID,drugID]);
  
  [self DELETE:[NSString stringWithFormat:API_UpdateDrug, PHRAppStatus.currentBaby.profileId,presID,drugID] parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
  
}

- (void)requestDeletePrescription:(NSString *)presID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty]) {
    return;
  }
  
  DLog(@"%@",[NSString stringWithFormat:API_MedicineNote, PHRAppStatus.currentBaby.profileId,presID]);
  
  [self DELETE:[NSString stringWithFormat:API_MedicineNote, PHRAppStatus.currentBaby.profileId,presID] parameters:nil success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
  
}


#pragma mark - Baby growth
// Baby growth


#pragma mark - Baby Sleep
- (NSURLSessionDataTask*)requestGetListBabySleepWithId:(NSString *)babyId andNumberPage:(int)numberPage
                                             completed:(void (^) (MFRession *responseObject))completion error:(PHRResponseError)errorBlock {
  return [self GET:[NSString stringWithFormat:API_GetListBabySleep, babyId, numberPage] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    MFRession *response = [MFRession responseObjectWithRequestOperation:responseObject error:nil];
    if (completion) {
      DLog(@"%@", response);
      completion(response);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestAddNewBabySleep:(BabySleepModel *)babySleep andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  int totalHour = [babySleep.morning_time_sleep intValue] + [babySleep.afternoon_time_sleep intValue] + [babySleep.night_time_sleep intValue];
  NSDictionary *params = @{
                           KEY_LifeStyleNote_Time_Sleep   : [NSString stringWithFormat:@"%@",babySleep.time_start_sleep],
                           KEY_LifeStyleNote_Time_WakeUp  : babySleep.time_wake_up,
                           KEY_LifeStyleNote_Total_time   : [NSString stringWithFormat:@"%d", totalHour],
                           KEY_BabySleep_Morning          : babySleep.morning_time_sleep,
                           KEY_BabySleep_Afternoon        : babySleep.afternoon_time_sleep,
                           KEY_BabySleep_Night            : babySleep.night_time_sleep,
                           };
  [self callWebServicesWithBabyApi:API_AddBabySleep andParam:params withCompleted:successBlock error:errorBlock];
}

#pragma mark - Baby Milk

- (NSURLSessionDataTask*)requestGetListBabyMilkWithId:(NSString *)babyId andNumberPage:(int)numberPage
                                           completion:(void (^) (MFRession *responseObject))completion error:(PHRResponseError)errorBlock {
  return [self GET:[NSString stringWithFormat:API_GetListBabyMilk, babyId, numberPage] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    MFRession *response = [MFRession responseObjectWithRequestOperation:responseObject error:nil];
    NSString *status = response.status;
    if (completion && [status isEqualToString:KEY_SUCCESS]) {
      DLog(@"%@",response);
      completion(response);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestAddNewBabyMilkWithObj:(BabyMilkModel *)babyMilk andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_BabyMilk_Time          : babyMilk.time_drink_milk,
                           KEY_Alert                  : babyMilk.alert,
                           KEY_BabyMilk_Method        : babyMilk.drink_method,
                           KEY_Calories               : babyMilk.calories,
                           KEY_BabyMilk_BreastTime    : babyMilk.breast_time
                           };
  
  [self callWebServicesWithBabyApi:API_AddNewBabyMilk andParam:params withCompleted:successBlock error:errorBlock];
}

- (void)requestAddNewBottleMilk:(BabyMilkModel *)babyMilk andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  
  NSDictionary *params = @{
                           KEY_BabyMilk_Time          : babyMilk.time_drink_milk,
                           KEY_Alert                  : babyMilk.alert,
                           KEY_BabyMilk_Method        : babyMilk.drink_method,
                           KEY_Calories               : babyMilk.calories,
                           KEY_BabyMilk_Bottle_Milk   : babyMilk.bottle_milk_volume,
                           KEY_BabyMilk_Type          : babyMilk.milk_type
                           };
  NSLog(@"%@",params);
  [self callWebServicesWithBabyApi:API_AddNewBabyMilk andParam:params withCompleted:successBlock error:errorBlock];
}

//update milk
- (void)requestUpdateMilk:(BabyMilkModel *)babyMilk andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  
  NSDictionary *params = @{
                           KEY_BabyMilk_Time          : babyMilk.time_drink_milk,
                           KEY_Alert                  : babyMilk.alert,
                           KEY_BabyMilk_Method        : babyMilk.drink_method,
                           KEY_Calories               : babyMilk.calories,
                           KEY_BabyMilk_BreastTime    : babyMilk.breast_time,
                           KEY_BabyMilk_Bottle_Milk   : babyMilk.breast_time
                           };
  NSLog(@"%@",params);
  
  [self PUT:[NSString stringWithFormat:API_UpdateBabyMilk,PHRAppStatus.currentBaby.profileId, babyMilk.id] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
  
  
}

#pragma mark - Baby Diaper

- (NSURLSessionDataTask*)requestGetListBabyDiapersWithId:(NSString *)babyID andNumberPage:(int)numberPage completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  return [self GET:[NSString stringWithFormat:API_GetListBabyDiapers, babyID, numberPage] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestAddNewBabyDiaperWithObj:(Diaper *)babyDiaper andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_BabyDiaper_Time      : babyDiaper.time_pee_poo,
                           KEY_Alert                : babyDiaper.alert,
                           KEY_BabyDiaper_Color     : babyDiaper.color,
                           KEY_MedicineNote_Method  : babyDiaper.method,
                           KEY_BabyDiaper_State     : babyDiaper.state,
                           KEY_Note                 : babyDiaper.note
                           };
  [self callWebServicesWithBabyApi:API_AddNewBabyDiaper andParam:params withCompleted:successBlock error:errorBlock];
}

- (void)requestUpdateDiaper:(Diaper *)babyDiaper andCompletion:(void (^)(MFRession *))completion error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_BabyDiaper_Time      : babyDiaper.time_pee_poo,
                           KEY_Alert                : babyDiaper.alert,
                           KEY_BabyDiaper_Color     : babyDiaper.color,
                           KEY_MedicineNote_Method  : babyDiaper.method,
                           KEY_BabyDiaper_State     : babyDiaper.state,
                           KEY_Note                 : babyDiaper.note
                           };
  NSLog(@"%@ - %@",params,babyDiaper.diaperID);
  [self PUT:[NSString stringWithFormat:API_UpdateBabyDiaper, PHRAppStatus.currentBaby.profileId, [babyDiaper.diaperID intValue]] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    MFRession *response = [MFRession responseObjectWithRequestOperation:responseObject error:nil];
    if (completion) {
      completion(response);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

#pragma mark - Progress Course

- (void)requestAddNewProgressCourseWithObjNote:(ProgressCourse *)progressCourse
                                  andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_DateRecord                 : progressCourse.datetime_record,
                           KEY_ProgressCourse_Hospital    : progressCourse.hospital,
                           KEY_ProgressCourse_Record_Url  : progressCourse.medical_record_url,
                           KEY_ProgressCourse_Status      : progressCourse.status,
                           KEY_Note                       : progressCourse.note
                           };
  [self callWebServicesWithApi:API_AddNewProgressCourse andParam:params withCompleted:successBlock error:errorBlock];
}

- (void)requestGetDetailProgressCourse:(NSString*)activeStandardId completion:(void (^)(MFRession *))completion{
  NSString *nameApi = [NSString stringWithFormat:API_GetDetailProgressCourse,activeStandardId];
  [self callWebServicesWithGetApi:nameApi andCompleted:completion];
}

- (void)requestGetListMedicineNoteForPatient:(NSString *)patientCode hospCode:(NSString*)hospCode completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  //API_GetListDiseases
  [self GET:[NSString stringWithFormat:API_GetMedicineNote_ProgressCourse, patientCode, hospCode] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}
#pragma mark - Add New Temperature

- (void)requestDetailTemperatureWithId:(NSString *)temperatureID type:(NSString*)temperatureType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock {
  
  [self GET:[NSString stringWithFormat:API_UpdateTempeture, PHRAppStatus.currentStandard.profileId,temperatureType, temperatureID] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (NSURLSessionDataTask*)requestGetListTemperaturePhysiologyWithTypeAndDuration:(NSString *)profileId withTemperatureType:(int)temperatureType andDuration:(NSString*)duration completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  //API_TemperatureGetList
  
  NSString *type;
  
  if(temperatureType == PHRChartTemperature){
    type = @"01";
  }else if(temperatureType == PHRChartBloodPressure){
    type = @"04";
  }else if(temperatureType == PHRChartHeartRate){
    type = @"02";
  }else if(temperatureType == PHRChartPrespiratory){
    type = @"03";
  }else{
    type = @"00";
  }
  DLog(@"%@", [NSString stringWithFormat:API_StandardTemperatureGetListWithDuration, profileId, type,duration]);
  return [self GET:[NSString stringWithFormat:API_StandardTemperatureGetListWithDuration, profileId, type,duration] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

//---- New API For Add Temperature -----

- (void)requestAddNewTemperaturePhysiology:(TemperaturePhysiologyModel *)temperatureItem completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty] || !temperatureItem) {
    return;
  }
  
  NSDictionary *params = @{KEY_TEMPERATURE : temperatureItem.temperature ? temperatureItem.temperature : @"",
                           KEY_HEART_RATE : temperatureItem.heartRate ? temperatureItem.heartRate : @"",
                           KEY_RESPIRATORY : temperatureItem.respiratory ? temperatureItem.respiratory : @"",
                           KEY_LOW_BLOOD_PRESSURE : temperatureItem.lowBloodPressure ? temperatureItem.lowBloodPressure : @"",
                           KEY_HIGH_BLOOD_PRESSURE : temperatureItem.highBloodPressure ? temperatureItem.highBloodPressure : @"",
                           KEY_DateRecord : temperatureItem.date,
                           KEY_Note : temperatureItem.note ? temperatureItem.note : @""};
  NSString *temperatureType = [temperatureItem serverType];
  DLog(@"requestAddNewFood: \n%@ \n foodType: %@", params,temperatureType);
  [self POST:[NSString stringWithFormat:API_StandardAddNewTemperature, PHRAppStatus.currentStandard.profileId, temperatureType] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

//New Update API For Temperature
- (void)requestUpdateTemperature:(TemperaturePhysiologyModel*)temperatureItem andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{KEY_TEMPERATURE : temperatureItem.temperature ? temperatureItem.temperature : @"",
                           KEY_HEART_RATE : temperatureItem.heartRate ? temperatureItem.heartRate : @"",
                           KEY_RESPIRATORY : temperatureItem.respiratory ? temperatureItem.respiratory : @"",
                           KEY_LOW_BLOOD_PRESSURE : temperatureItem.lowBloodPressure ? temperatureItem.lowBloodPressure : @"",
                           KEY_HIGH_BLOOD_PRESSURE : temperatureItem.highBloodPressure ? temperatureItem.highBloodPressure : @"",
                           KEY_DateRecord : temperatureItem.date,
                           KEY_Note : temperatureItem.note ? temperatureItem.note : @""};
  //NSString *temperatureType = [NSString stringWithFormat:@"0%d",temperatureItem.type + 1];
  NSString *temperatureType = [temperatureItem serverType];
  
  DLog(@"Update %@",[NSString stringWithFormat:API_UpdateTempeture,PHRAppStatus.currentStandard.profileId,temperatureType, temperatureItem.TemperaturePhysiologyID]);
  
  [self PUT:[NSString stringWithFormat:API_UpdateTempeture,PHRAppStatus.currentStandard.profileId,temperatureType, temperatureItem.TemperaturePhysiologyID] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
  
}


- (void)requestDeleteStandardTemperature:(NSString *)temperatureId temperatureType:(NSString*) temperatureType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  DLog(@"KEY_ID:%@",temperatureId);
  DLog("%@",[NSString stringWithFormat:API_TemperatureDelete, PHRAppStatus.currentStandard.profileId,temperatureType, temperatureId]);
  
  NSString *type;
  if([temperatureType isEqualToString:@"01"]){
    type = @"01";
  }else if([temperatureType isEqualToString:@"02"]){
    type = @"04";
  }else if([temperatureType isEqualToString:@"03"]){
    type = @"02";
  }else if([temperatureType isEqualToString:@"04"]){
    type = @"03";
  }else{
    type = @"00";
  }
  
  [self DELETE:[NSString stringWithFormat:API_TemperatureDelete, PHRAppStatus.currentStandard.profileId,type, temperatureId] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSString *status = responseObject[KEY_Status];
    DLog(@"%@", responseObject);
    if (successBlock && [status isEqualToString:KEY_SUCCESS]) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

//New API
- (NSURLSessionDataTask*)requestGetTimeLineTemperature:(NSString *)profileId withTemperatureType:(int)temperatureType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSString *type;
  if(temperatureType == PHRChartTemperature){
    type = @"01";
  }else if(temperatureType == PHRChartBloodPressure){
    type = @"04";
  }else if(temperatureType == PHRChartHeartRate){
    type = @"02";
  }else if(temperatureType == PHRChartPrespiratory){
    type = @"03";
  }
  
  NSLog(@"%@",[NSString stringWithFormat:API_GetTimeLineTemperature, profileId, type,pageNumber]);
  return [self GET:[NSString stringWithFormat:API_GetTimeLineTemperature, profileId, type,pageNumber] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}


#pragma mark - Standard Life Style
- (void)requestAddNewLifeStyle:(LifeStyleNoteModel *)lifeStyleNote completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_LifeStyleNote_Time_Sleep   : lifeStyleNote.time_start_sleep,
                           KEY_LifeStyleNote_Time_WakeUp  : lifeStyleNote.time_wake_up,
                           KEY_LifeStyleNote_Total_time   : lifeStyleNote.total_hour_sleep,
                           KEY_LifeStyleNote_Rating_Sleep : [NSString stringWithFormat:@"%d",lifeStyleNote.rating_sleep],
                           KEY_LifeStyleNote_Time_Awake   : lifeStyleNote.time_awake,
                           KEY_Note                       : lifeStyleNote.note,
                           };
  
  [self callWebServicesWithApi:API_AddNewLifeStyleNote andParam:params withCompleted:successBlock error:errorBlock];
}

- (void)requestGetListLifeStyle:(NSString *)profileId andPageNumber:(int)numberPage completion:(void (^)(MFRession *))completion {
  NSString *nameApi = [NSString stringWithFormat:API_GetListLifeStyleNote, profileId, numberPage];
  [self callWebServicesWithGetApi:nameApi andCompleted:completion];
}

#pragma mark - Standard Diseases
- (void)requestAddNewDiseases:(DiseasesModel *)diseases completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_datetime_record                 : diseases.datetime_record,
                           KEY_hospital_name    : diseases.hospital,
                           KEY_disease_name      : diseases.disease_name,
                           //KEY_ProgressCourse_Record_Url  : diseases.medical_record_url,
                           //KEY_Note                       : diseases.note,
                           };
  [self callWebServicesWithApi:API_AddNewDiseases andParam:params withCompleted:successBlock error:errorBlock];
}

- (void)requestGetListDiseases:(NSString *)numberPage completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  //API_GetListDiseases
  NSLog(@"%@",[NSString stringWithFormat:API_GetListDiseases, PHRAppStatus.currentStandard.profileId, numberPage]);
  [self GET:[NSString stringWithFormat:API_GetListDiseases, PHRAppStatus.currentStandard.profileId, numberPage] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}
#pragma mark - Public Methods API

- (NSURLSessionDataTask*)requestGetListData:(NSString *)profileId andNumberPage:(int)numberPage andMethod:(NSString *)method completion:(void (^)(MFRession *))completion {
  NSString *nameApi = [NSString stringWithFormat:method, profileId, numberPage];
  return [self callWebServicesWithGetApi:nameApi andCompleted:completion];
}

- (void)requestGetDetail:(NSString *)profileId and:(NSString *)objectId andMethod:(NSString *)method completion:(void (^)(MFRession *))completion {
  NSString *nameApi = [NSString stringWithFormat:method, profileId, objectId];
  [self callWebServicesWithGetApi:nameApi andCompleted:completion];
}

- (void)requestDeleteObject:(NSString *)profileId and:(NSString *)objectId andMethod:(NSString *)method completion:(void (^)(MFResponse *))completion {
  [self DELETE:[NSString stringWithFormat:method, profileId, objectId] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSDictionary *json = (NSDictionary *)responseObject;
    MFResponse *response = [MFResponse responseObjectWithRequestOperation:json error:nil];
    DLog(@"Request -- %@ -- ", task.originalRequest);
    DLog(@"Success -- %@ -- ", response);
    if (completion) {
      completion(response);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    DLog(@"%@", error.description);
    MFResponse *response = [MFResponse responseObjectWithRequestOperation:nil error:error];
    if (completion) {
      completion(response);
    }
  }];
}

- (void)requestUpdateData:(NSString *)method andProdileId:(NSString *)profileId andObjectId:(NSString *)objectId
                withParam:(NSDictionary *)params completion:(void (^)(MFRession *))completion {
  [self PUT:[NSString stringWithFormat:method, profileId, objectId] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSDictionary *json = (NSDictionary *)responseObject;
    MFRession *result = [MFRession responseObjectWithRequestOperation:json error:nil];
    if (completion) {
      completion(result);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    DLog(@"%@", error.description);
    MFRession *response = [MFRession responseObjectWithRequestOperation:nil error:error];
    if (completion) {
      completion(response);
    }
  }];
}

#pragma mark - Public Method

- (NSURLSessionDataTask*)callWebServicesWithGetApi:(NSString *)nameApi andCompleted:(void (^)(MFRession *))completion {
  return [self GET:nameApi parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSDictionary *json = (NSDictionary *)responseObject;
    MFRession *response = [MFRession responseObjectWithRequestOperation:json error:nil];
    DLog(@"Request -- %@ -- ", task.originalRequest);
    DLog(@"Success -- %@ -- ", response);
    if (completion) {
      completion(response);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error.description);
    MFRession *response = [MFRession responseObjectWithRequestOperation:nil error:error];
    if (error.code != NSURLErrorCancelled && completion) {
      completion(response);
    }
  }];
}

- (void)callWebServicesWithApi:(NSString *)api andParam:(NSDictionary *)params
                 withCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  
  [self POST:[NSString stringWithFormat:api, PHRAppStatus.currentStandard.profileId] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSString *status = responseObject[KEY_Status];
    if ([status isEqualToString:KEY_SUCCESS] && successBlock) {
      successBlock(responseObject);
    }
    else if ([status isEqualToString:KEY_FAIL] && errorBlock) {
      errorBlock(responseObject[KEY_Message]);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)callWebServicesWithBabyApi:(NSString *)api andParam:(id)params
                     withCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self POST:[NSString stringWithFormat:api, PHRAppStatus.currentBaby.profileId] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSString *status = responseObject[KEY_Status];
    if (successBlock && [status isEqualToString:KEY_SUCCESS]) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

#pragma mark - Baby Food

- (void)requestAddNewBabyFoodWithObj:(ChildrenFoodModel *)babyFood andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_BabyFood_Time      : babyFood.date,
                           KEY_BabyFood           : babyFood.food,
                           KEY_BabyFood_ImgURL    : babyFood.imageUrl,
                           KEY_BabyFood_Meal_Type : babyFood.mealType,
                           KEY_BabyFood_Kcal      : babyFood.kcal,
                           KEY_Note               : babyFood.note,
                           };
  [self callWebServicesWithBabyApi:API_AddNewBabyFood andParam:params withCompleted:successBlock error:errorBlock];
}

- (NSURLSessionDataTask*)requestGetListBabyFoods:(NSString *)babyID andNumberPage:(int)numberPage completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  //API_StandardHealthGetList
  return [self GET:[NSString stringWithFormat:API_GetListBabyFood, babyID, numberPage] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestGetDetailBabyFoodsWithId:(NSString *)babyID completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSLog(@"activeBaby--%@ -- %@",PHRAppStatus.currentBaby.profileId,babyID);
  [self GET:[NSString stringWithFormat:API_GetDetailBabyFood, PHRAppStatus.currentBaby.profileId, babyID] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestUpdateBabyFood:(ChildrenFoodModel*)babyFoodModel andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  NSDictionary *params = @{KEY_BabyFood_Time : babyFoodModel.date,
                           KEY_BabyFood_Kcal : babyFoodModel.kcal,
                           KEY_BabyFood_Meal_Type : babyFoodModel.mealType,
                           KEY_BabyFood : babyFoodModel.food,
                           KEY_BabyFood_ImgURL : babyFoodModel.imageUrl,
                           KEY_Note : babyFoodModel.note ? babyFoodModel.note : @"",};
  
  [self PUT:[NSString stringWithFormat:API_UpdateBabyFood,PHRAppStatus.currentBaby.profileId, babyFoodModel.childrenFoodID] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestDeleteBabyFood:(NSString *)babyFoodId andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock{
  [self DELETE:[NSString stringWithFormat:API_StandardHealthEditOrDelete, PHRAppStatus.currentBaby.profileId, babyFoodId] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSString *status = responseObject[KEY_Status];
    if (successBlock && [status isEqualToString:KEY_SUCCESS]) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

#pragma mark - Baby TimeLine

- (void)requestGetListBabytimeLineWithId:(NSString *)babyID andNumberLimit:(int)limit completed:(void (^) (MFRession *responseObject))completion error:(PHRResponseError)errorBlock {
  [self GET:[NSString stringWithFormat:API_GetListBabyTimeLine, babyID, limit] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSDictionary *json = (NSDictionary *)responseObject;
    MFRession *response = [MFRession responseObjectWithRequestOperation:json error:nil];
    DLog(@"Request -- %@ -- ", task.originalRequest);
    DLog(@"Success -- %@ -- ", response);
    if (completion) {
      completion(response);
    }
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

#pragma mark - Upload Image

- (void)uploadProfileImageToServer:(UIImage *)primaryPhoto andCompletion:(void (^) (id responseObject))completion {
  NSData *imageData = UIImageJPEGRepresentation(primaryPhoto, 1.0);
  if (!PHRAppStatus.currentStandard || !imageData) {
    return;
  }
  NSString *hostInfo = [[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Host"];
  
  hostInfo = [hostInfo stringByAppendingString:[NSString stringWithFormat:PHRAPIBasePathUpload, PHRAppStatus.currentStandard.profileId]];
  
  NSDictionary *param;
  
  AFHTTPRequestOperationManager *manager = [AFHTTPRequestOperationManager manager];
  
  // 1. Create `AFHTTPRequestSerializer` which will create your request.
  AFHTTPRequestSerializer *serializer = [AFHTTPRequestSerializer serializer];
  [serializer setValue:@"multipart/form-data" forHTTPHeaderField:@"Content-Type"];
  [serializer setValue:PHRAppStatus.token forHTTPHeaderField: @"token"];
  manager.requestSerializer = serializer;
  
  // 2. Create an `NSMutableURLRequest`.
  
  NSMutableURLRequest *request = [serializer multipartFormRequestWithMethod:@"POST" URLString:hostInfo parameters:param constructingBodyWithBlock:^(id<AFMultipartFormData> formData) {
    [formData appendPartWithFileData:imageData
                                name:@"file"
                            fileName:@"image.jpeg"
                            mimeType:@"image/jpeg"];
    
  } error:nil];
  
  
  // 3. Create and use `AFHTTPRequestOperationManager` to create an `AFHTTPRequestOperation` from the `NSMutableURLRequest` that we just created.
  AFHTTPRequestOperation *operation = [manager HTTPRequestOperationWithRequest:request
                                                                       success:^(AFHTTPRequestOperation *operation, id responseObject) {
                                                                         DLog(@"Success %@", responseObject);
                                                                         if (completion) {
                                                                           completion(responseObject);
                                                                         }
                                                                       } failure:^(AFHTTPRequestOperation *operation, NSError *error) {
                                                                         UIAlertView *alert = [[UIAlertView alloc]initWithTitle:@"Error!" message:@"The document attached has failed to upload." delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil, nil];
                                                                         [alert show];
                                                                         [operation cancel];
                                                                         NSLog(@"Failure %@", error.description);
                                                                       }];
  
  // 4. Set the progress block of the operation.
  [operation setUploadProgressBlock:^(NSUInteger __unused bytesWritten,
                                      long long totalBytesWritten,
                                      long long totalBytesExpectedToWrite) {
    DLog(@"Wrote %lld/%lld", totalBytesWritten, totalBytesExpectedToWrite);
    //        float progress = (float)totalBytesWritten/(float)totalBytesExpectedToWrite;
  }];
  
  // 5. Begin!
  [operation start];
}

- (void)uploadBackgroundToServer:(UIImage *)primaryPhoto andCompletion:(void (^) (MFResponse *responseObject))completion {
  NSData *imageData = UIImageJPEGRepresentation(primaryPhoto, 1.0);
  if (!PHRAppStatus.currentStandard || !imageData) {
    return;
  }
  NSString *hostInfo = [[NSBundle mainBundle] objectForInfoDictionaryKey:@"API_Host_Upload"];
  
  hostInfo = [hostInfo stringByAppendingString:[NSString stringWithFormat:PHRAPIBasePathUpload, PHRAppStatus.currentStandard.profileId]];
  
  NSMutableURLRequest *request = [[NSMutableURLRequest alloc] initWithURL:[NSURL URLWithString:hostInfo]];
  [request setCachePolicy:NSURLRequestUseProtocolCachePolicy];
  [request setHTTPShouldHandleCookies:NO];
  [request setTimeoutInterval:30];
  [request setHTTPMethod:@"POST"];
  
  NSString *boundary = @"unique-consistent-string";
  
  // set Content-Type in HTTP header
  NSString *contentType = @"multipart/form-data";
  [request setValue:contentType forHTTPHeaderField: @"Content-Type"];
  
  [request setValue:PHRAppStatus.token forHTTPHeaderField: @"token"];
  
  // post body
  NSMutableData *body = [NSMutableData data];
  
  // add params (all params are strings)
  [body appendData:[[NSString stringWithFormat:@"--%@\r\n", boundary] dataUsingEncoding:NSUTF8StringEncoding]];
  [body appendData:[[NSString stringWithFormat:@"Content-Disposition: form-data; name=%@\r\n\r\n", @"imageCaption"] dataUsingEncoding:NSUTF8StringEncoding]];
  [body appendData:[[NSString stringWithFormat:@"%@\r\n", @"Some Caption"] dataUsingEncoding:NSUTF8StringEncoding]];
  
  // add image data
  if (imageData) {
    [body appendData:[[NSString stringWithFormat:@"--%@\r\n", boundary] dataUsingEncoding:NSUTF8StringEncoding]];
    [body appendData:[[NSString stringWithFormat:@"Content-Disposition: form-data; name=%@; filename=eimg.jpge\r\n", @"imageFormKey"] dataUsingEncoding:NSUTF8StringEncoding]];
    [body appendData:[@"Content-Type: image/jpeg\r\n\r\n" dataUsingEncoding:NSUTF8StringEncoding]];
    [body appendData:imageData];
    [body appendData:[[NSString stringWithFormat:@"\r\n"] dataUsingEncoding:NSUTF8StringEncoding]];
  }
  
  [body appendData:[[NSString stringWithFormat:@"--%@--\r\n", boundary] dataUsingEncoding:NSUTF8StringEncoding]];
  
  
  
  // setting the body of the post to the reqeust
  [request setHTTPBody:body];
  
  // set the content-length
  NSString *postLength = [NSString stringWithFormat:@"%lu", (unsigned long)[body length]];
  [request setValue:postLength forHTTPHeaderField:@"Content-Length"];
  
  [NSURLConnection sendAsynchronousRequest:request queue:[NSOperationQueue currentQueue] completionHandler:^(NSURLResponse *response, NSData *data, NSError *error) {
    if(data.length > 0) {
      NSDictionary *json = [NSJSONSerialization JSONObjectWithData:data options:kNilOptions error:&error];
      MFResponse *response = [MFResponse responseObjectWithRequestOperation:json error:error];
      DLog(@"Success -- %@ -- %@", json, response);
      if (completion) {
        completion(response);
      }
    }
    else {
      if (completion) {
        completion(nil);
      }
    }
  }];
}

- (void)requestChangeBackgroundBaby:(NSString *)urlPhoto {
  NSDictionary *params = @{ KEY_Baby_URL : urlPhoto };
  [self PUT:[NSString stringWithFormat:API_ChangeBackgroundBB] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"result -- %@", responseObject);
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    DLog(@"%@", error.description);
  }];
}

- (void)requestChangeBackgroundStangard:(NSString *)urlPhoto {
  NSDictionary *params = @{ KEY_Standard_URL : urlPhoto };
  [self PUT:[NSString stringWithFormat:API_ChangeBackgroundST] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"result -- %@", responseObject);
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    DLog(@"%@", error.description);
  }];
}

//---- New API For Food -----

- (void)requestAddNewFood:(FoodItem *)foodItem completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty] || !foodItem) {
    return;
  }
  
  NSDictionary *params = @{KEY_Calories : foodItem.calories ? foodItem.calories : @"",
                           KEY_Carbohydrate : foodItem.carbohydrates ? foodItem.carbohydrates : @"",
                           KEY_Total_Fat : foodItem.totalFat ? foodItem.totalFat : @"",
                           KEY_Eating_Time : foodItem.date,
                           KEY_Note : foodItem.note ? foodItem.note : @""};
  NSString *foodType = [NSString stringWithFormat:@"0%d",foodItem.type + 1];
  DLog(@"requestAddNewFood: \n%@ \n foodType: %@", params,foodType);
  [self POST:[NSString stringWithFormat:API_StandardFoodAddNew, PHRAppStatus.currentStandard.profileId, foodType] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

#pragma mark - New Food API Get Chart List
- (NSURLSessionDataTask*)requestGetListFoodWithDuration:(NSString*)duration FoodType:(int)foodType andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSString *type = [NSString stringWithFormat:@"0%d",foodType + 1];
  return [self GET:[NSString stringWithFormat:API_StandardFoodGetListWithDuration, profileId, type, duration] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

#pragma mark - New Food API get detail
//New Request detail body measurement API
- (void)requestDetailFoodWithId:(NSString *)foodID healthType:(NSString*)foodType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock {
  
  [self GET:[NSString stringWithFormat:API_StandardFoodGetDetail, PHRAppStatus.currentStandard.profileId,foodType, foodID] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

//New Update API
- (void)requestUpdateFood:(FoodItem*)foodItem andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{KEY_Calories : foodItem.calories ? foodItem.calories : @"",
                           KEY_Carbohydrate : foodItem.carbohydrates ? foodItem.carbohydrates : @"",
                           KEY_Total_Fat : foodItem.totalFat ? foodItem.totalFat : @"",
                           KEY_Eating_Time : foodItem.date,
                           KEY_Rating_Satisfied : foodItem.ratingSatisfied,
                           KEY_Note : foodItem.note ? foodItem.note : @""};
  NSString *type = [NSString stringWithFormat:@"0%d",foodItem.type + 1];
  [self PUT:[NSString stringWithFormat:API_StandardFoodEdit,PHRAppStatus.currentStandard.profileId,type, foodItem.foodID] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

//New API
- (NSURLSessionDataTask*)requestGetTimeLineFood:(NSString *)profileId withFoodType:(int)foodType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  //API_StandardHealthGetList
  
  NSString *type = [NSString stringWithFormat:@"0%d",foodType + 1];
  NSLog(@"%@",[NSString stringWithFormat:API_StandardFoodGetListTimeLine, profileId, type,pageNumber]);
  return [self GET:[NSString stringWithFormat:API_StandardFoodGetListTimeLine, profileId, type,pageNumber] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestDeleteStandardFood:(NSString *)foodID foodType:(NSString*) foodType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self DELETE:[NSString stringWithFormat:API_StandardFoodDelete, PHRAppStatus.currentStandard.profileId,foodType, foodID] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSString *status = responseObject[KEY_Status];
    DLog(@"%@", responseObject);
    if (successBlock && [status isEqualToString:KEY_SUCCESS]) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

//----------------- Fitness ---------------------
#pragma mark - New Food API Get Chart List
- (NSURLSessionDataTask*)requestGetListFitnessWithDuration:(NSString*)duration fitnessType:(int)fitnessType andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSString *type = [NSString stringWithFormat:@"0%d",fitnessType + 1];
  return [self GET:[NSString stringWithFormat:API_StandardFitnessGetListWithDuration, profileId, type, duration] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (NSURLSessionDataTask*)requestGetTimeLineFitness:(NSString *)profileId withFitnessType:(int)fitnessType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  //API_StandardHealthGetList
  
  NSString *type = [NSString stringWithFormat:@"0%d",fitnessType + 1];
  return [self GET:[NSString stringWithFormat:API_StandardFitnessGetListTimeLine, profileId, type,pageNumber] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestDeleteStandardFitness:(NSString *)fitnessID fitnessType:(NSString*) fitnessType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self DELETE:[NSString stringWithFormat:API_StandardFitnessDelete, PHRAppStatus.currentStandard.profileId,fitnessType, fitnessID] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSString *status = responseObject[KEY_Status];
    DLog(@"%@", responseObject);
    if (successBlock && [status isEqualToString:KEY_SUCCESS]) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

#pragma mark - New Fitness API get detail
- (void)requestDetailFitnessWithId:(NSString *)fitnessID fitnessType:(NSString*)fitnessType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock {
  
  [self GET:[NSString stringWithFormat:API_StandardFitnessGetDetail, PHRAppStatus.currentStandard.profileId,fitnessType, fitnessID] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestAddNewFitness:(FitnessModel *)fitnessModel completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty] || !fitnessModel) {
    return;
  }
  
  NSDictionary *params = @{KEY_Fitness_Date : fitnessModel.date ? fitnessModel.date : @"",
                           KEY_Step_Count : fitnessModel.step ? fitnessModel.step : @"",
                           KEY_Walking_Run : fitnessModel.walkrun ? fitnessModel.walkrun : @"",
                           KEY_Note : fitnessModel.note ? fitnessModel.note : @""};
  NSString *foodType = [NSString stringWithFormat:@"0%d",fitnessModel.type + 1];
  DLog(@"requestAddNewFood: \n%@ \n foodType: %@", params,foodType);
  [self POST:[NSString stringWithFormat:API_StandardFitnessAddNew, PHRAppStatus.currentStandard.profileId, foodType] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

- (void)requestEditFitness:(FitnessModel *)fitnessModel completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty] || !fitnessModel) {
    return;
  }
  
  NSDictionary *params = @{KEY_Fitness_ID : fitnessModel.fitnessID ? fitnessModel.fitnessID : @"",
                           KEY_Fitness_Date : fitnessModel.date ? fitnessModel.date : @"",
                           KEY_Step_Count : fitnessModel.step ? fitnessModel.step : @"",
                           KEY_Walking_Run : fitnessModel.walkrun ? fitnessModel.walkrun : @"",
                           KEY_Note : fitnessModel.note ? fitnessModel.note : @""};
  NSString *foodType = [NSString stringWithFormat:@"0%d",fitnessModel.type + 1];
  DLog(@"requestAddNewFood: \n%@ \n foodType: %@", params,foodType);
  [self POST:[NSString stringWithFormat:API_StandardFitnessAddNew, PHRAppStatus.currentStandard.profileId, foodType] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

//------------------ Baby Food ------------------------
#pragma mark - New Food API Get Chart List
- (NSURLSessionDataTask*)requestGetListBabyFoodWithDuration:(NSString*)duration andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSLog(@"%@",[NSString stringWithFormat:API_BabyFoodGetListWithDuration, profileId, duration]);
  return [self GET:[NSString stringWithFormat:API_BabyFoodGetListWithDuration, profileId, duration] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

// ---------------- Baby Growth ----------------------
#pragma mark - New Food API Get Chart List
- (NSURLSessionDataTask*)requestGetListBabyGrowthWithDuration:(NSString*)duration growthType:(int)growthType andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSString *type = [NSString stringWithFormat:@"0%d",growthType + 1];
  NSLog(@"%@",[NSString stringWithFormat:API_BabyGrowthGetListWithDuration, profileId, type, duration]);
  return [self GET:[NSString stringWithFormat:API_BabyGrowthGetListWithDuration, profileId, type, duration] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestDetailBabyGrowthWithId:(NSString *)babyGrowthID babyGrowthType:(NSString*)babyGrowthType andCompletion:(void (^) (PHRResponseSuccess))successBlock error:(PHRResponseError)errorBlock {
  
  [self GET:[NSString stringWithFormat:API_BabyGrowthGetDetail, PHRAppStatus.currentBaby.profileId,babyGrowthType, babyGrowthID] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestAddNewBabyGrowth:(BabyGrowth *)babyGrowth completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  if (!PHRAppStatus.token || [PHRAppStatus.token isEmpty] || !babyGrowth) {
    return;
  }
  
  NSDictionary *params = @{KEY_Height : babyGrowth.height ? babyGrowth.height : @"",
                           KEY_Weight : babyGrowth.weight ? babyGrowth.weight : @"",
                           KEY_DoctorNote : babyGrowth.doctorNote ? babyGrowth.doctorNote : @"",
                           KEY_datetime_record : babyGrowth.dateTime,
                           KEY_ParentNote : babyGrowth.parentNote ? babyGrowth.parentNote : @""};
  NSString *growthType = [NSString stringWithFormat:@"0%d",babyGrowth.type + 1];
  DLog(@"requestAddNewFood: \n%@ \n foodType: %@", params,growthType);
  [self POST:[NSString stringWithFormat:API_BabyGrowthAddNew, PHRAppStatus.currentBaby.profileId, growthType] parameters:params success:^(NSURLSessionDataTask *task, id responseObject) {
    DLog(@"%@", responseObject);
    // Success
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask *task, NSError *error) {
    [self handleErrorResponse:error callback:errorBlock];
  }];
}

- (void)requestUpdateBabyGrowth:(BabyGrowth*)babyGrowth andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSDictionary *params = @{
                           KEY_Height : babyGrowth.height ? babyGrowth.height : @"",
                           KEY_Weight : babyGrowth.weight ? babyGrowth.weight : @"",
                           KEY_DoctorNote : babyGrowth.doctorNote ? babyGrowth.doctorNote : @"",
                           KEY_datetime_record : babyGrowth.dateTime,
                           KEY_ParentNote : babyGrowth.parentNote ? babyGrowth.parentNote : @""};
  NSString *type = [NSString stringWithFormat:@"0%d",babyGrowth.type + 1];
  [self PUT:[NSString stringWithFormat:API_BabyGrowthEdit,PHRAppStatus.currentBaby.profileId,type, babyGrowth.growthId] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (NSURLSessionDataTask*)requestGetTimeLineBabyGrowth:(NSString *)profileId withBabyGrowthType:(int)babyGrowthType andPageNumber:(NSString*)pageNumber  completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  //API_StandardHealthGetList
  
  NSString *type = [NSString stringWithFormat:@"0%d",babyGrowthType + 1];
  // NSLog(@"%@",[NSString stringWithFormat:API_StandardFoodGetListTimeLine, profileId, type,pageNumber]);
  return [self GET:[NSString stringWithFormat:API_BabyGrowthGetListTimeLine, profileId, type,pageNumber] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestDeleteBabyGrowth:(NSString *)babyGrowthID babyGrowthType:(NSString*) babyGrowthType andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self DELETE:[NSString stringWithFormat:API_BabyGrowthDelete, PHRAppStatus.currentBaby.profileId,babyGrowthType, babyGrowthID] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    NSString *status = responseObject[KEY_Status];
    DLog(@"%@", responseObject);
    if (successBlock && [status isEqualToString:KEY_SUCCESS]) {
      successBlock(responseObject);
    }
  } failure:^(NSURLSessionDataTask * _Nullable task, NSError * _Nonnull error) {
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

//-------------- Life Style

#pragma mark - New Food API Get Chart List
- (NSURLSessionDataTask*)requestGetListLifeStyleWithDuration:(NSString*)duration andProfileID:(NSString *)profileId completed:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  NSLog(@"%@",[NSString stringWithFormat:API_StandardLifeStyleGetListWithDuration, profileId, duration]);
  return [self GET:[NSString stringWithFormat:API_StandardLifeStyleGetListWithDuration, profileId, duration] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (error.code != NSURLErrorCancelled && errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

// -------------------------------- Sync ----------------------------------------
- (void)callWebServicesSynchronizePHRToServer:(NSString *)api profileID:(NSString*)profileID type:(NSString*)type uuid:(NSString*)uuid andParam:(id)params withCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self POST:[NSString stringWithFormat:api, profileID, type, uuid] parameters:params success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"Sync Temperature:%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"Sync Temperature:%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestSynchronizeBodyMeasurement:(NSArray *)arrayBodyMeasurement profileID:(NSString*)profileID uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self POST:[NSString stringWithFormat:API_SyncStandardBodyMeasurement, profileID, uuid] parameters:arrayBodyMeasurement success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
   // DLog(@"Sync Temperature:%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
   // DLog(@"Sync Temperature:%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestSynchronizeTemperature:(NSArray *)arrayTemperature profileID:(NSString*)profileID type:(NSString*)type uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  DLog(@"Type Tem------------>:%@",type);
  NSString *typeTem = @"01";
  if([type isEqualToString:@"02"]){
    typeTem = @"04";
  }else if([type isEqualToString:@"03"]){
    typeTem = @"02";
  }
  else if([type isEqualToString:@"04"]){
    typeTem = @"03";
  }
  [self callWebServicesSynchronizePHRToServer:API_SyncStandardTemperature profileID:profileID type:typeTem uuid:uuid andParam:arrayTemperature withCompleted:successBlock error:errorBlock];
}

- (void)requestSynchronizeStandardFood:(NSArray *)arrayStandardFood profileID:(NSString*)profileID type:(NSString*)type uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self callWebServicesSynchronizePHRToServer:API_SyncStandardFood profileID:profileID type:type uuid:uuid andParam:arrayStandardFood withCompleted:successBlock error:errorBlock];
}

- (void)requestSynchronizeStandardLifeStyle:(NSArray *)arrayLifeStype profileID:(NSString*)profileID uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self POST:[NSString stringWithFormat:API_SyncStandardLifeStyle, profileID, uuid] parameters:arrayLifeStype success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestSynchronizeStandardFitness:(NSArray *)arrayFitness profileID:(NSString*)profileID type:(NSString*) type uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self callWebServicesSynchronizePHRToServer:API_SyncStandardFitness profileID:profileID type:type uuid:uuid andParam:arrayFitness withCompleted:successBlock error:errorBlock];
}

- (void)requestSynchronizeBabyGrowth:(NSArray *)arrayBabyGrowth profileID:(NSString*)profileID type:(NSString*) type uuid:(NSString*)uuid andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self callWebServicesSynchronizePHRToServer:API_SyncBabyGrowth profileID:profileID type:type uuid:uuid andParam:arrayBabyGrowth withCompleted:successBlock error:errorBlock];
}

- (void)requestActiveForSync:(NSString*)uuid profileID:(NSString*)profileID andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self PUT:[NSString stringWithFormat:API_SyncActive,profileID, uuid] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestValidateForSync:(NSString*)uuid profileID:(NSString*)profileID andCompleted:(PHRResponseSuccess)successBlock error:(PHRResponseError)errorBlock {
  [self PUT:[NSString stringWithFormat:API_SyncValidateUDID,profileID, uuid] parameters:nil success:^(NSURLSessionDataTask * _Nonnull task, id _Nonnull responseObject) {
    DLog(@"%@", responseObject);
    [self handleResponse:responseObject completed:successBlock error:errorBlock];
  } failure:^(NSURLSessionDataTask * _Nonnull task, NSError * _Nonnull error) {
    DLog(@"%@", error);
    if (errorBlock) {
      errorBlock(error.localizedDescription);
    }
  }];
}

- (void)requestActiveForSync:(NSString*)udid profileID:(NSString*)profileID {
  [PHRAppDelegate showLoading];
  [[PHRClient instance] requestActiveForSync:udid profileID: profileID andCompleted:^(id response) {
    [PHRAppDelegate hideLoading];
    //[self requestSyncListStandardLifeStyle:[self testData] withProfileID:PHRAppStatus.currentStandard.profileId type:@"02" andUDID:udid];
  } error:^(NSString *error) {
    [PHRAppDelegate hideLoading];
    [NSUtils showMessage:error withTitle:APP_NAME];
  }];
}

- (void)requestValidateUDID:(NSString*)udid profileID:(NSString*)profileID {
  [PHRAppDelegate showLoading];
  [[PHRClient instance] requestValidateForSync:udid profileID: profileID andCompleted:^(id response) {
    [PHRAppDelegate hideLoading];
    
  } error:^(NSString *error) {
    [PHRAppDelegate hideLoading];
    [NSUtils showMessage:error withTitle:APP_NAME];
  }];
}

// ------------------------------------- Movie Talk API ---------------------------------------------

@end
