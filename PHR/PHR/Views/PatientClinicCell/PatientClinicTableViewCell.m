//
//  PatientClinicTableViewCell.m
//  PHR
//
//  Created by Tran Hoang Ha on 10/6/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PatientClinicTableViewCell.h"
#import "PatientClinicViewModel.h"

@interface PatientClinicTableViewCell()
@property (nonatomic, weak) IBOutlet UILabel *labelPatientCode;
@property (nonatomic, weak) IBOutlet UILabel *labelHospName;
@end

@implementation PatientClinicTableViewCell

- (void)awakeFromNib {
  [super awakeFromNib];
  // Initialization code
}

+ (CGFloat)cellHeight {
  return 86;
}

- (void)setViewModelForCell:(PatientClinicViewModel *)viewModel {
  _labelHospName.text = viewModel.hospName;
  _labelPatientCode.text = viewModel.patientCode;
}

@end
