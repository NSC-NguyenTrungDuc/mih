//
//  BookingViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/28/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "iCarousel.h"
#import "TriangleView.h"
#import "PatientClinicViewModel.h"
#import "TopMenuScrollView.h"
#import "PatientClinicViewModel.h"

@interface BookingViewController : Base2ViewController <iCarouselDelegate, iCarouselDataSource, TopMenuDelegate>
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet TopMenuScrollView *tabbarType;
@property (nonatomic, weak) IBOutlet iCarousel *carouselView;
@property (nonatomic, strong) PatientClinicViewModel *patientClinicAccount;
@end
