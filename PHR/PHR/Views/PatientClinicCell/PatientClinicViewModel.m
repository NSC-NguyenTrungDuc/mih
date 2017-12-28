//
//  PatientClinicViewModel.m
//  PHR
//
//  Created by Tran Hoang Ha on 10/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PatientClinicViewModel.h"

@implementation PatientClinicViewModel
- (instancetype)initWithModel:(id)model {
  PatientClinic *objPatientClinic = (PatientClinic *)model;
  self = [super init];
  if (self) {
    self.patientCode = objPatientClinic.userName;
    self.hospName = objPatientClinic.hospName;
    self.model = model;
  }
  return self;
}
@end
