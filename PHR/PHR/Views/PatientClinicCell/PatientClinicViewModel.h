//
//  PatientClinicViewModel.h
//  PHR
//
//  Created by Tran Hoang Ha on 10/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "PatientClinic.h"

@interface PatientClinicViewModel : NSObject
@property (nonatomic, copy) NSString *patientCode;
@property (nonatomic, copy) NSString *hospName;
@property (nonatomic, strong) PatientClinic *model;
- (instancetype)initWithModel:(id)model;
@end
