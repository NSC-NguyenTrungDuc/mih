//
//  PatientClinic.h
//
//  Created by Tran Hoang Ha on 10/10/16
//  Copyright (c) 2016 __MyCompanyName__. All rights reserved.
//

#import <Foundation/Foundation.h>



@interface PatientClinic : NSObject <NSCoding, NSCopying>

@property (nonatomic, strong) NSString *password;
@property (nonatomic, strong) NSString *userName;
@property (nonatomic, strong) NSString *patientCode;
@property (nonatomic, strong) NSString *accountClinicId;
@property (nonatomic, strong) NSString *hospName;
@property (nonatomic, strong) NSString *hospCode;
@property (nonatomic, assign) double activeClinicAccountFlg;

+ (instancetype)modelObjectWithDictionary:(NSDictionary *)dict;
- (instancetype)initWithDictionary:(NSDictionary *)dict;
- (NSDictionary *)dictionaryRepresentation;

@end
