//
//  AboutViewController.h
//  PHR
//
//  Created by SonNV1368 on 10/8/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface AboutViewController : Base2ViewController <UITextViewDelegate>
@property (strong, nonatomic) IBOutlet UITextView *textViewMessage;
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (weak, nonatomic) IBOutlet UILabel *lblBuildVersion;

@end
