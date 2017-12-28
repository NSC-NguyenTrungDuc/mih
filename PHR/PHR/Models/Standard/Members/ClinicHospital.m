//
//  ClinicHospital.m
//  PHR
//
//  Created by Luong Le Hoang on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ClinicHospital.h"

@implementation ClinicHospital

- (instancetype)initWithDict:(NSDictionary *)dict{
    if (self = [self init]) {
        self.hospitalCode = [Validator getSafeString:dict[@"hosp_code"]];
        self.hospitalName = [Validator getSafeString:dict[@"hosp_name"]];
        self.address = [Validator getSafeString:dict[@"address"]];
        self.tel = [Validator getSafeString:dict[@"tel"]];
    }
    return self;
}

@end
