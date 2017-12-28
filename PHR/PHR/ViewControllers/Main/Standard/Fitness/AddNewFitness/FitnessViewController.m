//
//  FitnessViewController.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FitnessViewController.h"

@interface FitnessViewController ()

@end

@implementation FitnessViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self initView];
}

- (void)initView {
    self.view.backgroundColor = [UIColor whiteColor];
    [self setupNavigationBarTitle:kLocalizedString(kTitleFitness) titleIcon:@"Icon_Fitness" rightItem:kLocalizedString(kSave)];
    
    if(self.addType == PHRFitnessAddTypeStepCount){
         [self.lbScreenTitle setText:kLocalizedString(kChartAddNewStepCount)];
    } else {
         [self.lbScreenTitle setText:kLocalizedString(kChartAddNewWalkingRunDistance)];
    }
   

    [self.lbScreenTitle setStyleRegularToLabelWithSize:14.0];
    
    [self.lbStepCountTitle setStyleRegularToLabelWithSize:12.0];
    [self.lbSteps setStyleRegularToLabelWithSize:10.0];

    self.txtStep = [[PHRTextField alloc] initCusTomTextFieldWithTextSize:26.0 andTextColor:PHR_COLOR_DATE_TIME];
    [self.txtStep setFrame:self.txtStepCount.frame];
    self.txtStep.delegate = self;
    [self.txtStep setTranslatesAutoresizingMaskIntoConstraints:NO];
    [self.txtStepCount addSubview:self.txtStep];
    
    [self.txtStepCount addConstraint:[NSLayoutConstraint constraintWithItem:self.txtStep
                                                              attribute:NSLayoutAttributeTop
                                                              relatedBy:NSLayoutRelationEqual
                                                                 toItem:self.txtStepCount
                                                              attribute:NSLayoutAttributeTop
                                                             multiplier:1.0
                                                               constant:0.0]];
    
    [self.txtStepCount addConstraint:[NSLayoutConstraint constraintWithItem:self.txtStep
                                                              attribute:NSLayoutAttributeLeading
                                                              relatedBy:NSLayoutRelationEqual
                                                                 toItem:self.txtStepCount
                                                              attribute:NSLayoutAttributeLeading
                                                             multiplier:1.0
                                                               constant:0.0]];
    
    [self.txtStepCount addConstraint:[NSLayoutConstraint constraintWithItem:self.txtStep
                                                              attribute:NSLayoutAttributeBottom
                                                              relatedBy:NSLayoutRelationEqual
                                                                 toItem:self.txtStepCount
                                                              attribute:NSLayoutAttributeBottom
                                                             multiplier:1.0
                                                               constant:0.0]];
    
    [self.txtStepCount addConstraint:[NSLayoutConstraint constraintWithItem:self.txtStep
                                                              attribute:NSLayoutAttributeTrailing
                                                              relatedBy:NSLayoutRelationEqual
                                                                 toItem:self.txtStepCount
                                                              attribute:NSLayoutAttributeTrailing
                                                             multiplier:1.0
                                                               constant:0.0]];
    //Note
    [self.noteFitness setDelegate:self];
    self.noteFitness.text = kLocalizedString(kNote);
    self.noteFitness.textColor = [UIColor lightGrayColor];
    //
    self.lbSteps.text = kLocalizedString(kSteps);
    self.lbStepCountTitle.text = kLocalizedString(kChartStepCount);
    
    //View DateTimePicker
    self.viewDateTime.frame = CGRectMake(0, 2500, SCREEN_WIDTH, self.viewDateTime.frame.size.height);
    [self.view addSubview:self.viewDateTime];
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/


- (IBAction)pressDoneDateTime:(id)sender {

    [self hideDatePicker];
}

- (IBAction)pressHideDatePicker:(id)sender {
    [self hideDatePicker];
}

- (void)hideDatePicker {
    [UIView beginAnimations:nil context:nil];
    [UIView setAnimationDuration:0.5];
    [self.viewDateTime setFrame:CGRectMake(0, 2500, SCREEN_WIDTH, self.viewDateTime.frame.size.height)];
    [UIView commitAnimations];
}

@end
