	//
//  JSChartView.m
//  PHR
//
//  Created by Luong Le Hoang on 11/19/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "JSChartView.h"
#import "Base64.h"

@interface JSChartView (){
    
}
@property (nonatomic, assign) BOOL isLoaded;
@property (nonatomic, assign) BOOL isPendingDraw;
@property (nonatomic, strong) NSData *pendingData;
@end

@implementation JSChartView {
    
}

+ (JSChartView*)createViewWithType:(PHRBabyChartType)type {
    JSChartView *chart = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([JSChartView class]) owner:self options:nil] objectAtIndex:0];
    chart.chartType = type;
    return chart;
}
+ (JSChartView*)createStandardViewWithType:(PHRStandardChartType)type{
    JSChartView *chart = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([JSChartView class]) owner:self options:nil] objectAtIndex:0];
    chart.standardChartType = type;
    return chart;
}

- (void)awakeFromNib{
    [self.webview setDelegate:self];
}

- (void)setChartType:(PHRBabyChartType)chartType{
    _chartType = chartType;
    NSString *path = nil;
    switch (chartType) {
        case PHRBabyChartTypeGrowth: {
            path = @"www/baby/growth";
            break;
        }
        case PHRBabyChartTypeMotherMilk: {
            path = @"www/baby/milk_mother";
            break;
        }
        case PHRBabyChartTypeBottleMilk: {
            path = @"www/baby/milk_bottle";
            break;
        }
        case PHRBabyChartTypeDiaper: {
            path = @"www/baby/diaper";
            break;
        }
        default: {
            break;
        }
    }
    if (path) {
        _isLoaded = NO;
        NSURL *url = [[NSBundle mainBundle] URLForResource:path withExtension:@"html"];
        [self.webview loadRequest:[NSURLRequest requestWithURL:url]];
    }
}

- (void)setStandardChartType:(PHRStandardChartType)chartType{
    _standardChartType = chartType;
    NSString *path = nil;
    switch (chartType) {
        case PHRStandardChartTypeHealth: {
            path = @"www/standard/health";
            break;
        }
        case PHRStandardChartTypeFood: {
            path = @"www/standard/food";
            break;
        }
        case PHRStandardChartTypeLifeStyle: {
            path = @"www/standard/lifeStyle";
            break;
        }
        case PHRStandardChartTypeTemperature: {
            path = @"www/standard/temperature";
            break;
        }
        default: {
            break;
        }
    }
    if (path) {
        _isLoaded = NO;
        NSURL *url = [[NSBundle mainBundle] URLForResource:path withExtension:@"html"];
        [self.webview loadRequest:[NSURLRequest requestWithURL:url]];
    }
}


- (void)layoutSubviews{
    if (_isLoaded) {
        DLog(@"size = [%f, %f]", (CGFloat)self.bounds.size.width, (CGFloat)self.bounds.size.height);
        [self.webview stringByEvaluatingJavaScriptFromString:[NSString stringWithFormat:@"changeDimension(%f, %f)", (CGFloat)self.bounds.size.width, (CGFloat)self.bounds.size.height]];
    }
}

#pragma mark - Draw
- (void)drawGraph:(id)response{
    _pendingData = nil;
    NSData *jsonData = [NSJSONSerialization dataWithJSONObject:response options:NSJSONWritingPrettyPrinted error:nil];
    if (_isLoaded && self.webview) {
        [self drawGraphWithData:jsonData];
    }
    else{
        _isPendingDraw = YES;
        _pendingData = jsonData;
    }
}

- (void)drawGraphWithData:(NSData*)jsonData{
    if (!jsonData) {
        return;
    }
    _isPendingDraw = NO;
    [self.webview stringByEvaluatingJavaScriptFromString:[NSString stringWithFormat:@"drawGraph('%@')", [jsonData base64EncodedString]]];
    
}

- (void)showOrHideLoading:(BOOL)isShowed{
    if (isShowed){
        [PHRAppDelegate showLoadingInView:self.viewLoading];
    } else {
        [PHRAppDelegate hideLoadingInView:self.viewLoading];
    }
}

#pragma mark - WebView delegate

- (void)webViewDidStartLoad:(UIWebView *)webView {
    
}

- (void)webViewDidFinishLoad:(UIWebView *)webView {
    self.isLoaded = YES;
    [self setNeedsLayout];
    if (self.isPendingDraw) {
        [self drawGraphWithData:self.pendingData];
        self.pendingData = nil;
    }
}

- (BOOL) webView:(UIWebView *)webView shouldStartLoadWithRequest:(NSURLRequest *)request navigationType:(UIWebViewNavigationType)navigationType{
    // manicgraph:click_on_pie
    NSURL *URL = [request URL];
    if ([[URL scheme] isEqualToString:@"manicgraph"])
    {
        //        NSString *functionString = [URL resourceSpecifier];
        //
        //        return NO;
    }
    DLog(@"URL =====> %@", URL);
    return YES;
}

- (void)transferDataToJavaScript {
//    if (self.chartInfor && self.chartInfor[@"content"][@"nodes"]) {
//        self.webview.hidden = NO;
//        // parse json string
//        NSData *jsonData = [NSJSONSerialization dataWithJSONObject:self.chartInfor options:NSJSONWritingPrettyPrinted error:nil];
//        [self.webview stringByEvaluatingJavaScriptFromString:[NSString stringWithFormat:@"start_draw('%@')", [jsonData base64EncodedString]]];
//    }else{
//        self.webview.hidden = YES;
//    }
}

- (void)loadChartFromJavaScript {
//    if (self.type == METTweetHistoryChartTweetHistory) {
//        [self.webview stringByEvaluatingJavaScriptFromString:[NSString stringWithFormat:@"startRequestHistory('%@')", [METTweetHistoryService getTweetHistoryUrlWith:self.startDate andEnd:self.endDate]]];
//    }
//    //Days of the week
//    else if (self.type == METTweetHistoryChartTweetDaysOfWeek) {
//        [self.webview stringByEvaluatingJavaScriptFromString:[NSString stringWithFormat:@"startRequestDaysOfWeek('%@')", [METTweetHistoryService getTweetDaysOfTheWeekUrlWith:self.startDate andEnd:self.endDate]]];
//    }
//    // Hours of the day
//    else if (self.type == METTweetHistoryChartTweetHoursOfDay) {
//        [self.webview stringByEvaluatingJavaScriptFromString:[NSString stringWithFormat:@"startRequestHoursOfDay('%@')", [METTweetHistoryService getTweetHoursOfTheDayUrlWith:self.startDate andEnd:self.endDate]]];
//    }
}



@end
