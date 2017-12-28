//
//  PHRMovieTalkViewController.h
//  PHR
//
//  Created by Tran Hoang Ha on 9/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Base2ViewController.h"
#import "PHRBookingModel.h"
#import "ChatViewController.h"

@interface PHRMovieTalkViewController : Base2ViewController
@property (nonatomic, strong) PHRBookingModel *model;
@property (nonatomic, strong) ChatViewController *chatVC;
@property (nonatomic, strong) NSString *callID;
- (void)callToDoctor;
@end
