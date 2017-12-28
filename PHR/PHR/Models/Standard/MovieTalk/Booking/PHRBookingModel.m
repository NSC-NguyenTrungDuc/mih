//
//  PHRBookingModel.m
//
//  Created by Tran Hoang Ha on 9/19/16
//  Copyright (c) 2016 SofiaMedix. All rights reserved.
//

#import "PHRBookingModel.h"


NSString *const kPHRBookingModelNawonYn = @"nawon_yn";
NSString *const kPHRBookingModelMtCallingId = @"mt_calling_id";
NSString *const kPHRBookingModelExaminationTime = @"examination_time";
NSString *const kPHRBookingModelPatientCode = @"patient_code";
NSString *const kPHRBookingModelSysId = @"sys_id";
NSString *const kPHRBookingModelPatientName = @"patient_name";
NSString *const kPHRBookingModelReservationCode = @"reservation_code";
NSString *const kPHRBookingModelDepartmentCode = @"department_code";
NSString *const kPHRBookingModelExaminationDate = @"examination_date";
NSString *const kPHRBookingModelPatientNameKana = @"patient_name_kana";
NSString *const kPHRBookingModelDoctorName = @"doctor_name";
NSString *const kPHRBookingModelDepartmentName = @"department_name";
NSString *const kPHRBookingModelDoctorCode = @"doctor_code";
NSString *const kPHRBookingModelReceptTime = @"recept_time";


@interface PHRBookingModel ()

- (id)objectOrNilForKey:(id)aKey fromDictionary:(NSDictionary *)dict;

@end

@implementation PHRBookingModel

@synthesize nawonYn = _nawonYn;
@synthesize mtCallingId = _mtCallingId;
@synthesize examinationTime = _examinationTime;
@synthesize patientCode = _patientCode;
@synthesize sysId = _sysId;
@synthesize patientName = _patientName;
@synthesize reservationCode = _reservationCode;
@synthesize departmentCode = _departmentCode;
@synthesize examinationDate = _examinationDate;
@synthesize patientNameKana = _patientNameKana;
@synthesize doctorName = _doctorName;
@synthesize departmentName = _departmentName;
@synthesize doctorCode = _doctorCode;
@synthesize receptTime = _receptTime;


+ (instancetype)modelObjectWithDictionary:(NSDictionary *)dict {
  return [[self alloc] initWithDictionary:dict];
}

- (instancetype)initWithDictionary:(NSDictionary *)dict {
  self = [super init];
  if(self && [dict isKindOfClass:[NSDictionary class]]) {
    self.nawonYn = [self objectOrNilForKey:kPHRBookingModelNawonYn fromDictionary:dict];
    self.mtCallingId = [self objectOrNilForKey:kPHRBookingModelMtCallingId fromDictionary:dict];
    self.examinationTime = [self objectOrNilForKey:kPHRBookingModelExaminationTime fromDictionary:dict];
    self.patientCode = [self objectOrNilForKey:kPHRBookingModelPatientCode fromDictionary:dict];
    self.sysId = [self objectOrNilForKey:kPHRBookingModelSysId fromDictionary:dict];
    self.patientName = [self objectOrNilForKey:kPHRBookingModelPatientName fromDictionary:dict];
    self.reservationCode = [self objectOrNilForKey:kPHRBookingModelReservationCode fromDictionary:dict];
    self.departmentCode = [self objectOrNilForKey:kPHRBookingModelDepartmentCode fromDictionary:dict];
    self.examinationDate = [self objectOrNilForKey:kPHRBookingModelExaminationDate fromDictionary:dict];
    self.patientNameKana = [self objectOrNilForKey:kPHRBookingModelPatientNameKana fromDictionary:dict];
    self.doctorName = [self objectOrNilForKey:kPHRBookingModelDoctorName fromDictionary:dict];
    self.departmentName = [self objectOrNilForKey:kPHRBookingModelDepartmentName fromDictionary:dict];
    self.doctorCode = [self objectOrNilForKey:kPHRBookingModelDoctorCode fromDictionary:dict];
    self.receptTime = [self objectOrNilForKey:kPHRBookingModelReceptTime fromDictionary:dict];
  }
  return self;
}

- (NSDictionary *)dictionaryRepresentation {
  NSMutableDictionary *mutableDict = [NSMutableDictionary dictionary];
  [mutableDict setValue:self.nawonYn forKey:kPHRBookingModelNawonYn];
  [mutableDict setValue:self.mtCallingId forKey:kPHRBookingModelMtCallingId];
  [mutableDict setValue:self.examinationTime forKey:kPHRBookingModelExaminationTime];
  [mutableDict setValue:self.patientCode forKey:kPHRBookingModelPatientCode];
  [mutableDict setValue:self.sysId forKey:kPHRBookingModelSysId];
  [mutableDict setValue:self.patientName forKey:kPHRBookingModelPatientName];
  [mutableDict setValue:self.reservationCode forKey:kPHRBookingModelReservationCode];
  [mutableDict setValue:self.departmentCode forKey:kPHRBookingModelDepartmentCode];
  [mutableDict setValue:self.examinationDate forKey:kPHRBookingModelExaminationDate];
  [mutableDict setValue:self.patientNameKana forKey:kPHRBookingModelPatientNameKana];
  [mutableDict setValue:self.doctorName forKey:kPHRBookingModelDoctorName];
  [mutableDict setValue:self.departmentName forKey:kPHRBookingModelDepartmentName];
  [mutableDict setValue:self.doctorCode forKey:kPHRBookingModelDoctorCode];
  [mutableDict setValue:self.receptTime forKey:kPHRBookingModelReceptTime];
  
  return [NSDictionary dictionaryWithDictionary:mutableDict];
}

- (NSString *)description  {
  return [NSString stringWithFormat:@"%@", [self dictionaryRepresentation]];
}

#pragma mark - Helper Method
- (id)objectOrNilForKey:(id)aKey fromDictionary:(NSDictionary *)dict {
  id object = [dict objectForKey:aKey];
  return [object isEqual:[NSNull null]] ? nil : object;
}


#pragma mark - NSCoding Methods

- (id)initWithCoder:(NSCoder *)aDecoder {
  self = [super init];
  self.nawonYn = [aDecoder decodeObjectForKey:kPHRBookingModelNawonYn];
  self.mtCallingId = [aDecoder decodeObjectForKey:kPHRBookingModelMtCallingId];
  self.examinationTime = [aDecoder decodeObjectForKey:kPHRBookingModelExaminationTime];
  self.patientCode = [aDecoder decodeObjectForKey:kPHRBookingModelPatientCode];
  self.sysId = [aDecoder decodeObjectForKey:kPHRBookingModelSysId];
  self.patientName = [aDecoder decodeObjectForKey:kPHRBookingModelPatientName];
  self.reservationCode = [aDecoder decodeObjectForKey:kPHRBookingModelReservationCode];
  self.departmentCode = [aDecoder decodeObjectForKey:kPHRBookingModelDepartmentCode];
  self.examinationDate = [aDecoder decodeObjectForKey:kPHRBookingModelExaminationDate];
  self.patientNameKana = [aDecoder decodeObjectForKey:kPHRBookingModelPatientNameKana];
  self.doctorName = [aDecoder decodeObjectForKey:kPHRBookingModelDoctorName];
  self.departmentName = [aDecoder decodeObjectForKey:kPHRBookingModelDepartmentName];
  self.doctorCode = [aDecoder decodeObjectForKey:kPHRBookingModelDoctorCode];
  self.receptTime = [aDecoder decodeObjectForKey:kPHRBookingModelReceptTime];
  return self;
}

- (void)encodeWithCoder:(NSCoder *)aCoder {
  [aCoder encodeObject:_nawonYn forKey:kPHRBookingModelNawonYn];
  [aCoder encodeObject:_mtCallingId forKey:kPHRBookingModelMtCallingId];
  [aCoder encodeObject:_examinationTime forKey:kPHRBookingModelExaminationTime];
  [aCoder encodeObject:_patientCode forKey:kPHRBookingModelPatientCode];
  [aCoder encodeObject:_sysId forKey:kPHRBookingModelSysId];
  [aCoder encodeObject:_patientName forKey:kPHRBookingModelPatientName];
  [aCoder encodeObject:_reservationCode forKey:kPHRBookingModelReservationCode];
  [aCoder encodeObject:_departmentCode forKey:kPHRBookingModelDepartmentCode];
  [aCoder encodeObject:_examinationDate forKey:kPHRBookingModelExaminationDate];
  [aCoder encodeObject:_patientNameKana forKey:kPHRBookingModelPatientNameKana];
  [aCoder encodeObject:_doctorName forKey:kPHRBookingModelDoctorName];
  [aCoder encodeObject:_departmentName forKey:kPHRBookingModelDepartmentName];
  [aCoder encodeObject:_doctorCode forKey:kPHRBookingModelDoctorCode];
  [aCoder encodeObject:_receptTime forKey:kPHRBookingModelReceptTime];
}

- (id)copyWithZone:(NSZone *)zone {
  PHRBookingModel *copy = [[PHRBookingModel alloc] init];
  if (copy) {
    copy.nawonYn = [self.nawonYn copyWithZone:zone];
    copy.mtCallingId = [self.mtCallingId copyWithZone:zone];
    copy.examinationTime = [self.examinationTime copyWithZone:zone];
    copy.patientCode = [self.patientCode copyWithZone:zone];
    copy.sysId = [self.sysId copyWithZone:zone];
    copy.patientName = [self.patientName copyWithZone:zone];
    copy.reservationCode = [self.reservationCode copyWithZone:zone];
    copy.departmentCode = [self.departmentCode copyWithZone:zone];
    copy.examinationDate = [self.examinationDate copyWithZone:zone];
    copy.patientNameKana = [self.patientNameKana copyWithZone:zone];
    copy.doctorName = [self.doctorName copyWithZone:zone];
    copy.departmentName = [self.departmentName copyWithZone:zone];
    copy.doctorCode = [self.doctorCode copyWithZone:zone];
    copy.receptTime = [self.receptTime copyWithZone:zone];
  }
  return copy;
}
@end
