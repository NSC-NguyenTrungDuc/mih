//
//  PHRBookingListViewController.h
//  PHR
//
//  Created by Tran Hoang Ha on 9/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Base2ViewController.h"
#import "PatientClinicViewModel.h"
#import "PHRMovieTalkViewController.h"

@interface PHRBookingListViewController : Base2ViewController
@property (nonatomic, strong) PatientClinicViewModel *patientClinicAccount;
@property (nonatomic, copy) void(^openMovietalkViewController)(PHRMovieTalkViewController *controller);
@end
