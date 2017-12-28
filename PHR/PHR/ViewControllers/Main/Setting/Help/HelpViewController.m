//
//  HelpViewController.m
//  PHR
//
//  Created by SonNV1368 on 10/13/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "HelpViewController.h"

@interface HelpViewController ()

@end

@implementation HelpViewController

- (void)viewDidLoad {
    [super viewDidLoad];
     [self setupUI];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void) setupUI{
    [self setupNavigationBarTitle:kLocalizedString(kHelpCenterTitle) titleIcon:nil rightItem:nil];
    
    [self.textViewMessage setText:kLocalizedString(kHelpCenterMessage)];
    [self.textViewMessage setEditable:NO];
}

- (void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [self setImageToBackground:self.imageBackground];
}

@end
