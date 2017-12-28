//
//  PatientClinic.m
//
//  Created by Tran Hoang Ha on 10/10/16
//  Copyright (c) 2016 __MyCompanyName__. All rights reserved.
//

#import "PatientClinic.h"


NSString *const kPatientClinicPassword = @"password";
NSString *const kPatientClinicUserName = @"user_name";
NSString *const kPatientClinicPatientCode = @"patient_code";
NSString *const kPatientClinicAccountClinicId = @"account_clinic_id";
NSString *const kPatientClinicHospName = @"hosp_name";
NSString *const kPatientClinicHospCode = @"hosp_code";
NSString *const kPatientClinicActiveClinicAccountFlg = @"active_clinic_account_flg";


@interface PatientClinic ()

- (id)objectOrNilForKey:(id)aKey fromDictionary:(NSDictionary *)dict;

@end

@implementation PatientClinic

@synthesize password = _password;
@synthesize userName = _userName;
@synthesize patientCode = _patientCode;
@synthesize accountClinicId = _accountClinicId;
@synthesize hospName = _hospName;
@synthesize hospCode = _hospCode;
@synthesize activeClinicAccountFlg = _activeClinicAccountFlg;


+ (instancetype)modelObjectWithDictionary:(NSDictionary *)dict
{
  return [[self alloc] initWithDictionary:dict];
}

- (instancetype)initWithDictionary:(NSDictionary *)dict
{
  self = [super init];
  
  // This check serves to make sure that a non-NSDictionary object
  // passed into the model class doesn't break the parsing.
  if(self && [dict isKindOfClass:[NSDictionary class]]) {
    self.password = [self objectOrNilForKey:kPatientClinicPassword fromDictionary:dict];
    self.userName = [self objectOrNilForKey:kPatientClinicUserName fromDictionary:dict];
    self.patientCode = [self objectOrNilForKey:kPatientClinicPatientCode fromDictionary:dict];
    self.accountClinicId = [self objectOrNilForKey:kPatientClinicAccountClinicId fromDictionary:dict];
    self.hospName = [self objectOrNilForKey:kPatientClinicHospName fromDictionary:dict];
    self.hospCode = [self objectOrNilForKey:kPatientClinicHospCode fromDictionary:dict];
    self.activeClinicAccountFlg = [[self objectOrNilForKey:kPatientClinicActiveClinicAccountFlg fromDictionary:dict] doubleValue];
    
  }
  
  return self;
  
}

- (NSDictionary *)dictionaryRepresentation
{
  NSMutableDictionary *mutableDict = [NSMutableDictionary dictionary];
  [mutableDict setValue:self.password forKey:kPatientClinicPassword];
  [mutableDict setValue:self.userName forKey:kPatientClinicUserName];
  [mutableDict setValue:self.patientCode forKey:kPatientClinicPatientCode];
  [mutableDict setValue:self.accountClinicId forKey:kPatientClinicAccountClinicId];
  [mutableDict setValue:self.hospName forKey:kPatientClinicHospName];
  [mutableDict setValue:self.hospCode forKey:kPatientClinicHospCode];
  [mutableDict setValue:[NSNumber numberWithDouble:self.activeClinicAccountFlg] forKey:kPatientClinicActiveClinicAccountFlg];
  
  return [NSDictionary dictionaryWithDictionary:mutableDict];
}

- (NSString *)description
{
  return [NSString stringWithFormat:@"%@", [self dictionaryRepresentation]];
}

#pragma mark - Helper Method
- (id)objectOrNilForKey:(id)aKey fromDictionary:(NSDictionary *)dict
{
  id object = [dict objectForKey:aKey];
  return [object isEqual:[NSNull null]] ? nil : object;
}


#pragma mark - NSCoding Methods

- (id)initWithCoder:(NSCoder *)aDecoder
{
  self = [super init];
  
  self.password = [aDecoder decodeObjectForKey:kPatientClinicPassword];
  self.userName = [aDecoder decodeObjectForKey:kPatientClinicUserName];
  self.patientCode = [aDecoder decodeObjectForKey:kPatientClinicPatientCode];
  self.accountClinicId = [aDecoder decodeObjectForKey:kPatientClinicAccountClinicId];
  self.hospName = [aDecoder decodeObjectForKey:kPatientClinicHospName];
  self.hospCode = [aDecoder decodeObjectForKey:kPatientClinicHospCode];
  self.activeClinicAccountFlg = [aDecoder decodeDoubleForKey:kPatientClinicActiveClinicAccountFlg];
  return self;
}

- (void)encodeWithCoder:(NSCoder *)aCoder
{
  
  [aCoder encodeObject:_password forKey:kPatientClinicPassword];
  [aCoder encodeObject:_userName forKey:kPatientClinicUserName];
  [aCoder encodeObject:_patientCode forKey:kPatientClinicPatientCode];
  [aCoder encodeObject:_accountClinicId forKey:kPatientClinicAccountClinicId];
  [aCoder encodeObject:_hospName forKey:kPatientClinicHospName];
  [aCoder encodeObject:_hospCode forKey:kPatientClinicHospCode];
  [aCoder encodeDouble:_activeClinicAccountFlg forKey:kPatientClinicActiveClinicAccountFlg];
}

- (id)copyWithZone:(NSZone *)zone
{
  PatientClinic *copy = [[PatientClinic alloc] init];
  
  if (copy) {
    
    copy.password = [self.password copyWithZone:zone];
    copy.userName = [self.userName copyWithZone:zone];
    copy.patientCode = [self.patientCode copyWithZone:zone];
    copy.accountClinicId = [self.accountClinicId copyWithZone:zone];
    copy.hospName = [self.hospName copyWithZone:zone];
    copy.hospCode = [self.hospCode copyWithZone:zone];
    copy.activeClinicAccountFlg = self.activeClinicAccountFlg;
  }
  
  return copy;
}


@end
