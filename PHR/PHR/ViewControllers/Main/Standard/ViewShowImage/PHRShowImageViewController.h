//
//  PHRShowImageViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 12/2/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface PHRShowImageViewController : UIViewController

@property (weak, nonatomic) IBOutlet UILabel *lbFileName;
@property (weak, nonatomic) IBOutlet UIImageView *imageToShow;
@property (weak, nonatomic) IBOutlet UIScrollView *scrollViewImage;
@property (weak, nonatomic) IBOutlet UIButton *btnCVlose;

@property (nonatomic, strong) UIImageView *imageView;

@end
