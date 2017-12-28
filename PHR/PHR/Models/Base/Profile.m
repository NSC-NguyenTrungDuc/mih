//
//  Person.m
//  PHR
//
//  Created by Luong Le Hoang on 10/13/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Profile.h"

@implementation Profile {
    
}

+ (Profile *)sharedManager {
  static dispatch_once_t pred = 0;
  static Profile *instance = nil;
  dispatch_once(&pred, ^{
    instance = [[Profile alloc] init];
  });
  return instance;
}

#pragma mark - Setter & Getter
- (void)setAvatar:(NSString *)avatar{
    _avatar = avatar;
    if (self.delegate && [self.delegate respondsToSelector:@selector(profile:updateAvatar:)]) {
        [self.delegate profile:self updateAvatar:avatar];
    }
}

- (void)setBirthday:(NSDate *)birthday{
    _birthday = birthday;
    if (_birthday) {
        _age = [self calculateAge:_birthday];
    }
}

#pragma mark - Init methods
- (instancetype)initWithDictionary:(NSDictionary *)data {
    self = [self init];
    if (self) {
    }
    
    return self;
}

- (instancetype)initWithCoder:(NSCoder *)decoder {
    self = [self init];
    if (self) {
        self.profileId = [decoder decodeObjectForKey:KEY_Id];
        self.name = [decoder decodeObjectForKey:KEY_FullName];
        self.gender = [decoder decodeObjectForKey:KEY_Gender];
        self.nameKana = [decoder decodeObjectForKey:KEY_FullNameKana];
        self.birthday = [decoder decodeObjectForKey:KEY_Birthday];
        self.avatar = [decoder decodeObjectForKey:KEY_PictureProfileUrl];
        self.relationship = [decoder decodeObjectForKey:KEY_Relationship];
        self.udid = [decoder decodeObjectForKey:@"udid"];
    }
    return self;
}

- (instancetype)initWithProfile:(Profile*)profile {
    self = [self init];
    if (self) {
        self.profileId = profile.profileId;
        self.name = profile.name;
        self.gender = profile.gender;
        self.nameKana = profile.nameKana;
        self.birthday = profile.birthday;
        self.avatar = profile.avatar;
        self.isActive = profile.isActive;
        self.udid = profile.udid;
    }
    return self;
}

- (void)encodeWithCoder:(NSCoder *)encoder {
    [encoder encodeObject:self.profileId forKey:KEY_Id];
    [encoder encodeObject:self.name forKey:KEY_FullName];
    [encoder encodeObject:self.gender forKey:KEY_Gender];
    [encoder encodeObject:self.nameKana forKey:KEY_FullNameKana];
    [encoder encodeObject:self.birthday forKey:KEY_Birthday];
    [encoder encodeObject:self.avatar forKey:KEY_PictureProfileUrl];
    [encoder encodeObject:self.relationship forKey:KEY_Relationship];
}

- (void)updateWithDictionary:(NSDictionary*)data {
    self.profileId = [Validator getSafeString:data[KEY_Id]];
    self.name = [Validator getSafeString:data[KEY_FullName]];
    self.nameKana = [Validator getSafeString:data[KEY_FullNameKana]];
    self.gender = [self genderFromKey:[Validator getSafeString:data[KEY_Gender]]];
    self.birthday = [NSUtils dateFromString:[Validator getSafeString:data[KEY_Birthday]] withFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    self.avatar = [Validator getSafeString:data[KEY_PictureProfileUrl]];
    
    self.isActive = [Validator getSafeBool:data[KEY_ActiveProfileFlag]];
    self.isBaby = [Validator getSafeBool:data[KEY_BabyFlag]];
    self.relationship = [Validator getSafeString:data[KEY_Relationship]];
  
    if ([[Validator getSafeString:data[@"master_flg"]] isEqualToString:@"1"]) {
      PHRAppStatus.is_fist_sync = [Validator getSafeString:data[KEY_is_Fist_Sync]];
      PHRAppStatus.latest_sync_time = [Validator getSafeString:data[KEY_Latest_Sync_Time]];
    }

    self.udid = [Validator getSafeString:data[@"udid"]];
}

#pragma mark - generate out side param

- (NSString*)stringBirthdayParam {
//#if DEBUG
//    NSAssert(self.birthday != nil, @"Birthday must be not nil");
//#endif
    NSDateFormatter *formatter = [[NSDateFormatter alloc] init];
    [formatter setDateFormat:PHR_BIRTHDAY_SERVER_FORMAT];
    return [formatter stringFromDate:self.birthday];
}


- (NSString*)stringGenderParam{
    if ([[self.gender lowercaseString] isEqualToString:[kLocalizedString(kSignUpFemale) lowercaseString]]) {
        return @"F";
    }
    return @"M";
}

- (NSString*)genderFromKey:(NSString*)key{
    if ([key isEqualToString:@"F"]) {
        return kLocalizedString(kSignUpFemale);
    }
    return kLocalizedString(kSignUpMale);
}

- (BOOL)isMen{
    return [[self stringGenderParam] isEqualToString:@"M"];
}

- (BOOL)checkActive{
    return self.isActive && [self.udid isEqualToString:PHRAppStatus.UDID];
}

-(int)calculateAge:(NSDate*)dateOfBirth{
    return [[NSDate date] timeIntervalSinceDate:dateOfBirth]/(60*60*24*365);
}

@end
