//
//  HealthRecordViewController.h
//  PHR
//
//  Created by BillyMobile on 7/15/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "iCarousel.h"
#import "TriangleView.h"
#import "PatientClinicViewModel.h"
#import "TopMenuScrollView.h"

@interface HealthRecordViewController : Base2ViewController <iCarouselDelegate, iCarouselDataSource, TopMenuDelegate>

@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet TopMenuScrollView *tabbarType;
@property (nonatomic, weak) IBOutlet iCarousel *carouselView;

@end
