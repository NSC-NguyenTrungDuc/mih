//
//  PHRTwoTabButton.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRTwoTabButton.h"
#import <PureLayout/PureLayout.h>

@implementation PHRTwoTabButton

/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/
- (void)awakeFromNib {
    [super awakeFromNib];
}
- (void)inititializeContent{
    self.labelTitleModeNoImageLeft.text = kLocalizedString(kSummaryData);
    self.labelTitleRight.text = kLocalizedString(kList);
    
    self.labelTitleLeft.hidden = YES;
    self.imageViewLeft.hidden = YES;
    self.labelTitleModeNoImageRight.hidden = YES;
    
    self.labelTitleLeft.textColor = [UIColor whiteColor];
    self.labelTitleRight.textColor = [UIColor whiteColor];
    self.labelTitleModeNoImageLeft.textColor = [UIColor whiteColor];
    self.labelTitleModeNoImageRight.textColor = [UIColor whiteColor];
    
    self.labelTitleLeft.font = [UIFont fontWithName:self.labelTitleLeft.font.fontName size:15.0];
    self.labelTitleRight.font = [UIFont fontWithName:self.labelTitleLeft.font.fontName size:15.0];
    self.labelTitleModeNoImageLeft.font = [UIFont fontWithName:self.labelTitleLeft.font.fontName size:15.0];
    self.labelTitleModeNoImageRight.font = [UIFont fontWithName:self.labelTitleLeft.font.fontName size:15.0];
    
    self.backgroundColor = [UIColor clearColor];
    self.viewLeftTab.backgroundColor = [UIColor clearColor];
    self.viewRightTab.backgroundColor = [UIColor clearColor];
    
    self.labelTitleLeft.backgroundColor = [UIColor clearColor];
    self.labelTitleRight.backgroundColor = [UIColor clearColor];
    self.labelTitleModeNoImageLeft.backgroundColor = [UIColor clearColor];
    self.labelTitleModeNoImageRight.backgroundColor = [UIColor clearColor];
    [self setupTapGesture];
}

- (void) setSelectedIndex:(NSInteger)selectedIndex{
    if (selectedIndex < 0 || selectedIndex > 1) {
        [self leftTabIndex];
    } else if (selectedIndex == TwoBarSelectedIndexSummary){
        [self leftTabIndex];
    } else {
        [self rightTabIndex];
    }
}

- (void) setFont:(CGFloat)fontSize {
    self.labelTitleLeft.font = [UIFont fontWithName:self.labelTitleLeft.font.fontName size:fontSize];
    self.labelTitleRight.font = [UIFont fontWithName:self.labelTitleLeft.font.fontName size:fontSize];
    self.labelTitleModeNoImageLeft.font = [UIFont fontWithName:self.labelTitleLeft.font.fontName size:fontSize];
    self.labelTitleModeNoImageRight.font = [UIFont fontWithName:self.labelTitleLeft.font.fontName size:fontSize];
}

- (void)setupTapGesture{
    //The setup code (in viewDidLoad in your view controller)
    UITapGestureRecognizer *leftTap = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(leftTabIndex)];
    UITapGestureRecognizer *rightTab = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(rightTabIndex)];
    [self.viewLeftTab addGestureRecognizer:leftTap];
    [self.viewRightTab addGestureRecognizer:rightTab];
}

- (void)leftTabIndex{
    _selectedIndex = TwoBarSelectedIndexSummary;
    self.viewLeftTab.backgroundColor = [[UIColor whiteColor] colorWithAlphaComponent:0.3];
    self.viewRightTab.backgroundColor = [UIColor clearColor] ;
    if (self.delegate) {
        [self.delegate selectedIndex:_selectedIndex ofTwoTabButton:self];
    }
}

- (void)rightTabIndex{
    _selectedIndex = TwoBarSelectedIndexList;
    self.viewRightTab.backgroundColor = [[UIColor whiteColor] colorWithAlphaComponent:0.3];
    self.viewLeftTab.backgroundColor = [UIColor clearColor] ;
    if (self.delegate) {
        [self.delegate selectedIndex:_selectedIndex ofTwoTabButton:self];
    }
}

- (void)addToView:(UIView*)superView delegate:(id)delegate{
    self.delegate = delegate;
    self.frame = [superView bounds];
    [superView addSubview:self];
    [self autoPinEdgeToSuperviewEdge:ALEdgeLeft withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeRight withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0.0];
    [self autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0.0];
    [self inititializeContent];
}

@end
