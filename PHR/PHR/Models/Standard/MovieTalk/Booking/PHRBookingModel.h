//
//  PHRBookingModel.h
//
//  Created by Tran Hoang Ha on 9/19/16
//  Copyright (c) 2016 SofiaMedix. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface PHRBookingModel : NSObject <NSCoding, NSCopying>

@property (nonatomic, strong) NSString *nawonYn;
@property (nonatomic, strong) NSString *mtCallingId;
@property (nonatomic, strong) NSString *examinationTime;
@property (nonatomic, strong) NSString *patientCode;
@property (nonatomic, strong) NSString *sysId;
@property (nonatomic, strong) NSString *patientName;
@property (nonatomic, strong) NSString *reservationCode;
@property (nonatomic, strong) NSString *departmentCode;
@property (nonatomic, strong) NSString *examinationDate;
@property (nonatomic, strong) NSString *patientNameKana;
@property (nonatomic, strong) NSString *doctorName;
@property (nonatomic, strong) NSString *departmentName;
@property (nonatomic, strong) NSString *doctorCode;
@property (nonatomic, strong) NSString *receptTime;
@property (nonatomic, strong) NSString *displayText;
@property (nonatomic, strong) UIColor *displayColor;
@property (nonatomic, strong) NSString *displayOn;
@property (nonatomic, strong) NSString *hospitalName;

+ (instancetype)modelObjectWithDictionary:(NSDictionary *)dict;
- (instancetype)initWithDictionary:(NSDictionary *)dict;
- (NSDictionary *)dictionaryRepresentation;

@end
