//
//  JSChartView.h
//  PHR
//
//  Created by Luong Le Hoang on 11/19/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>



@interface JSChartView : UIView <UIWebViewDelegate>{
    
}
@property (weak, nonatomic) IBOutlet UIView *viewLoading;
@property (assign, nonatomic) PHRBabyChartType chartType;
@property (assign, nonatomic) PHRStandardChartType standardChartType;
@property (weak, nonatomic) IBOutlet UIWebView *webview;
@property (strong, nonatomic) UIRefreshControl *refreshControl;

+ (JSChartView*)createViewWithType:(PHRBabyChartType)type;
+ (JSChartView*)createStandardViewWithType:(PHRStandardChartType)type;
- (void)drawGraph:(id)response;
- (void)drawGraphWithData:(NSData*)jsonData;
- (void)showOrHideLoading:(BOOL)isShowed;
@end
