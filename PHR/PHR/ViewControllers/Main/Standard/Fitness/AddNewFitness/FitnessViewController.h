//
//  FitnessViewController.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "PHREnums.h"//;


@interface FitnessViewController : Base2ViewController <UITextFieldDelegate, UITextViewDelegate>

@property (nonatomic, strong) PHRTextField *txtStep;

@property (weak, nonatomic) IBOutlet UILabel *lbStepCountTitle;
@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateTimeView;

@property (weak, nonatomic) IBOutlet UILabel *lbSteps;
@property (weak, nonatomic) IBOutlet UILabel *lbScreenTitle;
@property (weak, nonatomic) IBOutlet DALinedTextView *noteFitness;
@property (strong, nonatomic) IBOutlet UIView *viewDateTime;
@property (weak, nonatomic) IBOutlet UIView *txtStepCount;

@property (weak, nonatomic) IBOutlet UIDatePicker *pickerDateTime;


@property (nonatomic, assign) PHRFitnessAddType addType;
@end
