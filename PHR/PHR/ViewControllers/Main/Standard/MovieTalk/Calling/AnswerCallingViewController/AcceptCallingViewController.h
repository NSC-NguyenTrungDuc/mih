//
//  AcceptCallingViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/12/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <AVFoundation/AVFoundation.h>
#import "STKAudioPlayer.h"

@interface AcceptCallingViewController : UIViewController  <STKAudioPlayerDelegate>

@property (weak, nonatomic) IBOutlet UIButton *btnReject;
@property (weak, nonatomic) IBOutlet UIButton *btnAccept;
@property (nonatomic, strong) NSDictionary *dictUserInfo;
@property (weak, nonatomic) IBOutlet UIView *viewReject;
@property (weak, nonatomic) IBOutlet UIView *viewAccept;
@property (weak, nonatomic) IBOutlet UILabel *labelCallFrom;

@end
