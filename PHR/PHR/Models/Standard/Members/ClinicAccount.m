//
//  ClinicAccount.m
//  PHR
//
//  Created by Luong Le Hoang on 10/27/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "ClinicAccount.h"

@implementation ClinicAccount{
    
}

- (instancetype)initWithDict:(NSDictionary*)dict{
    if (self = [self init]) {
        self.clinicId = [Validator getSafeString:dict[@"account_clinic_id"]];
        if (!self.clinicId || [self.clinicId isEqualToString:@""]) {
            self.clinicId = [Validator getSafeString:dict[@"id"]];
        }
        self.patientCode = [Validator getSafeString:dict[@"user_name"]];
        if (!self.patientCode || [self.patientCode isEqualToString:@""]) {
            self.patientCode = [Validator getSafeString:dict[@"patient_code"]];
        }
        self.activeFlag = [Validator getSafeBool:dict[@"active_clinic_account_flg"]];
        self.hospital = [[ClinicHospital alloc] initWithDict:dict];
    }
    return self;
}

@end
