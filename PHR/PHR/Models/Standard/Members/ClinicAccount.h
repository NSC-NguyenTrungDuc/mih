//
//  ClinicAccount.h
//  PHR
//
//  Created by Luong Le Hoang on 10/27/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "ClinicHospital.h"

@interface ClinicAccount : NSObject{
    
}
@property (nonatomic, strong) NSString *clinicId;
@property (nonatomic, strong) NSString *patientCode;
@property (nonatomic, strong) NSString *password;
@property (nonatomic, strong) NSString *profileId;
@property (nonatomic, strong) ClinicHospital *hospital;
@property (nonatomic, assign) BOOL activeFlag;

- (instancetype)initWithDict:(NSDictionary*)dict;

@end
