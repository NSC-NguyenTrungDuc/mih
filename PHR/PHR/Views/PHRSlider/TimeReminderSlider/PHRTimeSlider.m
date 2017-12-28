//
//  PHRTimeSlider.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 11/5/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRTimeSlider.h"

#define TAG_SCROLLVIEW_HOUR 1
#define TAG_SCROLLVIEW_MINUTE 2

@implementation PHRTimeSlider {
  float screenWidth;
  float scrollViewWidth;
  float posYHour;
  float posYMinute;
  float labelHeight;
  float viewHeight;
  UIView *viewHighlight;
  int defaultHour;
  int defaultMinute;
}

- (void)initialize:(id)delegate {
  _delegate = delegate;
  viewHeight = self.frame.size.height;
  [self initView];
  NSCalendar *calendar = [NSCalendar currentCalendar];
    NSDateComponents *components = [calendar components:(NSCalendarUnitHour | NSCalendarUnitMinute) fromDate:[NSDate date]];
  defaultHour = (int)[components hour];
  defaultMinute = (int)[components minute];
  [self scrollToPosition:self.scrollViewHour at:defaultHour isAnimate:NO];
  [self scrollToPosition:self.scrollViewMinute at:defaultMinute isAnimate:NO];
}

- (void)initView {
  screenWidth = CGRectGetWidth([[UIScreen mainScreen] bounds]);
  scrollViewWidth = 50.0;
  labelHeight = 45;
  posYHour = viewHeight / 2 - labelHeight / 2;
  posYMinute = viewHeight / 2 - labelHeight / 2;
  [self initSliderHour];
  [self initSliderMinute];
  [self initViewHighlight];
}

- (void)initViewHighlight {
   viewHighlight = [[UIView alloc] initWithFrame:CGRectMake(self.scrollViewHour.frame.origin.x, viewHeight / 2 - labelHeight / 2, self.scrollViewMinute.frame.origin.x - self.scrollViewHour.frame.origin.x + scrollViewWidth, labelHeight)];
  [viewHighlight.layer setBorderColor:[UIColor colorWithRed:59./255. green:167./255. blue:222./255. alpha:1].CGColor];
  viewHighlight.layer.cornerRadius = 5.0;
  viewHighlight.userInteractionEnabled  = false;
  viewHighlight.backgroundColor = [UIColor colorWithRed:237./255. green:249./255. blue:253./255. alpha:1];
  [viewHighlight.layer setBorderWidth:3.5];
  
  UILabel *label = [[UILabel alloc] initWithFrame:viewHighlight.bounds];
  label.text = @":";
  label.font = [FontUtils aileronBoldWithSize:18];
  label.backgroundColor = [UIColor clearColor];
  label.textAlignment = NSTextAlignmentCenter;
  [viewHighlight addSubview:label];
  [self insertSubview:viewHighlight atIndex:0];

}

- (void)initViewAlpha {
  UIView *viewAlphaTop = [[UIView alloc] initWithFrame:CGRectMake(0, 0, screenWidth , viewHighlight.frame.origin.y)];
  viewAlphaTop.backgroundColor = [[UIColor whiteColor] colorWithAlphaComponent:0.7];
  viewAlphaTop.userInteractionEnabled = false;
  [self addSubview:viewAlphaTop];
  
  UIView *viewAlphaBottom = [[UIView alloc] initWithFrame:CGRectMake(0, viewHighlight.frame.origin.y + viewHighlight.frame.size.height, screenWidth, viewHeight - viewAlphaBottom.frame.size.height - viewHighlight.frame.size.height)];
  viewAlphaBottom.backgroundColor = [[UIColor whiteColor] colorWithAlphaComponent:0.7];
  viewAlphaBottom.userInteractionEnabled = false;
  [self addSubview:viewAlphaBottom];
}


- (void)initSliderHour {
  
  self.scrollViewHour = [[UIScrollView alloc] initWithFrame:CGRectMake(screenWidth / 2 - 50 - scrollViewWidth / 2, 0, scrollViewWidth, viewHeight)];
  self.scrollViewHour.delegate = self;
  self.scrollViewHour.tag = TAG_SCROLLVIEW_HOUR;
   self.scrollViewHour.backgroundColor = [UIColor clearColor];
  [self addSubview:self.scrollViewHour];
  [self drawSliderHour];
 
}

- (void)initSliderMinute {
  
  self.scrollViewMinute = [[UIScrollView alloc] initWithFrame:CGRectMake(screenWidth / 2 + 50 - scrollViewWidth / 2, 0, scrollViewWidth, viewHeight)];
  self.scrollViewMinute.delegate = self;
  self.scrollViewMinute.tag = TAG_SCROLLVIEW_MINUTE;
  self.scrollViewMinute.backgroundColor = [UIColor clearColor];
  [self addSubview:self.scrollViewMinute];
  [self drawSliderMinute];
}

- (void)drawSliderHour {
  
  int numberOfHour = 24;
  
  for (int i = 0; i < numberOfHour; i++) {
    
    [self addLabelHour:i];
    if (i == numberOfHour - 1) {
      posYHour += viewHeight / 2 - labelHeight / 2;
    }
  }
  
  [self.scrollViewHour setShowsVerticalScrollIndicator:NO];
  [self.scrollViewHour setShowsHorizontalScrollIndicator:NO];
  self.scrollViewHour.decelerationRate = UIScrollViewDecelerationRateNormal;
  self.scrollViewHour.bounces = NO;
  self.scrollViewHour.contentSize = CGSizeMake(scrollViewWidth, posYHour);
  
}

- (void)drawSliderMinute {
  
  int numberOfMinute = 60;
  for (int i = 0; i < numberOfMinute; i++) {
    
    [self addLabelMinute:i];
    if (i == numberOfMinute - 1) {
      posYMinute += viewHeight / 2 - labelHeight / 2;
    }
  }
  
  [self.scrollViewMinute setShowsVerticalScrollIndicator:NO];
  [self.scrollViewMinute setShowsHorizontalScrollIndicator:NO];
  self.scrollViewMinute.decelerationRate = UIScrollViewDecelerationRateNormal;
  self.scrollViewMinute.bounces = NO;
  self.scrollViewMinute.contentSize = CGSizeMake(scrollViewWidth, posYMinute);
}

- (void)addLabelHour:(NSInteger)index {
  
  UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(self.scrollViewHour.bounds.origin.x, posYHour, scrollViewWidth , labelHeight)];
  label.font = [FontUtils aileronBoldWithSize:22];
  label.text = [NSString stringWithFormat:@"%ld", index];
  label.tag = index;
  label.textAlignment = NSTextAlignmentCenter;
  posYHour += labelHeight;
  [self.scrollViewHour addSubview:label];
}

- (void)addLabelMinute:(NSInteger)index {
  
  UILabel *label = [[UILabel alloc] initWithFrame:CGRectMake(self.scrollViewMinute.bounds.origin.x, posYMinute, scrollViewWidth , labelHeight)];
  label.font = [FontUtils aileronBoldWithSize:22];
  label.text = [NSString stringWithFormat:@"%ld", index];
  label.tag = index;
  label.textAlignment = NSTextAlignmentCenter;
  posYMinute += labelHeight;
  [self.scrollViewMinute addSubview:label];
}

- (void)scrollViewDidScroll:(UIScrollView *)scrollView {
//  if (_delegate) {
//    [_delegate scrollViewTimeDidScroll:defaultHour andMinute:defaultMinute];
//  }
}

-(void)scrollViewDidEndDragging:(UIScrollView *)scrollView willDecelerate:(BOOL)decelerate {
  if (!decelerate) {
    [self calculateScrollPosition:scrollView isAnimate:YES];
  }
}

- (void)scrollViewDidEndDecelerating:(UIScrollView *)scrollView {
  [self calculateScrollPosition:scrollView isAnimate:YES];
}

- (void)calculateScrollPosition:(UIScrollView *)scrollView isAnimate:(BOOL)isAnimate {
  int index;
  index = roundf(scrollView.contentOffset.y / labelHeight);
  [self scrollToPosition:scrollView at:roundf(index) isAnimate:isAnimate];
}

- (void)scrollToPosition:(UIScrollView*)scrollView at:(int)index isAnimate:(BOOL)isAnimate {
  if (scrollView.tag == TAG_SCROLLVIEW_HOUR) {
    defaultHour = index;
    float yPos =  index * labelHeight;
    [self.scrollViewHour setContentOffset:CGPointMake(0, yPos) animated:isAnimate];
  } else {
    defaultMinute = index;
    float yPos =  index * labelHeight;
    [self.scrollViewMinute setContentOffset:CGPointMake(0, yPos) animated:isAnimate];
  }
  
    if (_delegate) {
      [_delegate scrollViewTimeDidScroll:defaultHour andMinute:defaultMinute];
    }

  
}

@end
