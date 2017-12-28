//
//  PolicyViewController.m
//  PHR
//
//  Created by SonNV1368 on 10/13/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "PolicyViewController.h"

@interface PolicyViewController ()

@end

@implementation PolicyViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupUI];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void) setupUI{
    [self setupNavigationBarTitle:kLocalizedString(kTermPoliciesTitle) titleIcon:nil rightItem:nil];

    [self.textViewMessage setText:kLocalizedString(kPolicyMessage)];
    [self.textViewMessage setEditable:NO];
}

- (void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [self setImageToBackground:self.imageBackground];
}

@end
