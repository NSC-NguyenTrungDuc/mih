//
//  PHRShowImageViewController.m
//  PHR
//
//  Created by DEV-MinhNN on 12/2/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRShowImageViewController.h"

@interface PHRShowImageViewController ()<UIScrollViewDelegate>

@end

@implementation PHRShowImageViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
    
    self.scrollViewImage.minimumZoomScale = 0.5;
    self.scrollViewImage.maximumZoomScale = 3.0;
    self.scrollViewImage.delegate = self;
    
    [self.btnCVlose.layer setBorderWidth:1.0];
    [self.btnCVlose.layer setBorderColor:PHR_COLOR_GRAY.CGColor];
    [self.btnCVlose.titleLabel setStyleRegularToLabelWithSize:11.0];
    [self.btnCVlose.layer setCornerRadius:4.0];
    [self.btnCVlose setTitle:@"閉じる" forState:UIControlStateNormal];

    [self.lbFileName setStyleRegularToLabelWithSize:14.0];
    [self.lbFileName sizeToFit];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewWillAppear:(BOOL)animated {
    [super viewWillAppear:animated];
    [self showImageInView:self.imageView];
}
/*
 #pragma mark - Navigation
 
 // In a storyboard-based application, you will often want to do a little preparation before navigation
 - (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
 // Get the new view controller using [segue destinationViewController].
 // Pass the selected object to the new view controller.
 }
 */

- (void)showImageInView:(UIImageView *)imageView {
    [self.imageToShow setImage:imageView.image];
    if ([imageView accessibilityIdentifier]) {
        [self.lbFileName setText:[NSString stringWithFormat:@"%@", [imageView accessibilityIdentifier]]];
    }
}

- (IBAction)pressCloseView:(id)sender {
    [self.navigationController popViewControllerAnimated:YES];
}

#pragma mark - UIScrollView Delegate

- (UIView *)viewForZoomingInScrollView:(UIScrollView *)scrollView {
    return self.imageToShow;
}

- (CGRect)zoomRectForScrollView:(UIScrollView *)scrollView withScale:(float)scale withCenter:(CGPoint)center {
    CGRect zoomRect;

    zoomRect.size.height = scrollView.frame.size.height / scale;
    zoomRect.size.width  = scrollView.frame.size.width  / scale;
    
    // choose an origin so as to get the right center.
    zoomRect.origin.x = center.x - (zoomRect.size.width  / 2.0);
    zoomRect.origin.y = center.y - (zoomRect.size.height / 2.0);
    
    return zoomRect;
}

@end
