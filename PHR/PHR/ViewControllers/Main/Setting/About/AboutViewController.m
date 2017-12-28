//
//  AboutViewController.m
//  PHR
//
//  Created by SonNV1368 on 10/8/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "AboutViewController.h"

@interface AboutViewController () 

@end

@implementation AboutViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
    [self setupNavigationBarTitle:kLocalizedString(kAboutTitle) titleIcon:nil rightItem:nil];
    self.textViewMessage.delegate = self;
    NSMutableParagraphStyle *paragraphStyle = NSMutableParagraphStyle.new;
    paragraphStyle.alignment                = NSTextAlignmentLeft;
//    NSURL *URL = [NSURL URLWithString: @"https://www.karte.clinic"];
    NSMutableAttributedString *text = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@", kLocalizedString(kAboutMessage)]];
//    [text addAttributes:@{ NSUnderlineStyleAttributeName : [NSNumber numberWithInteger:NSUnderlineStyleSingle] , NSLinkAttributeName: URL} range: NSMakeRange(kLocalizedString(kAboutMessage).length, kLocalizedString(kCompanyName).length)];
    [text addAttributes:@{  NSParagraphStyleAttributeName : paragraphStyle , NSFontAttributeName : [FontUtils aileronRegularWithSize:15]} range: NSMakeRange(0, text.length)];
    [self.textViewMessage setAttributedText:text];
    [self.textViewMessage setEditable:NO];
    [self.textViewMessage setSelectable:YES];
    self.textViewMessage.userInteractionEnabled = YES;
    self.textViewMessage.delaysContentTouches = NO;
     self.textViewMessage.dataDetectorTypes = UIDataDetectorTypeLink;
    [self.textViewMessage setScrollEnabled:NO];
    UITapGestureRecognizer *tapRecognizer = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(tappedTextView:)];
    [self.textViewMessage addGestureRecognizer:tapRecognizer];
    NSString * version = [[NSBundle mainBundle] objectForInfoDictionaryKey: @"CFBundleShortVersionString"];
    NSString * build = [[NSBundle mainBundle] objectForInfoDictionaryKey: (NSString *)kCFBundleVersionKey];
    
    NSString *buidVersion = [NSString stringWithFormat: @"PHR %@ - %@", version, build];
    self.lblBuildVersion.text = buidVersion;
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)tappedTextView:(UITapGestureRecognizer *)tapGesture {
    if (tapGesture.state != UIGestureRecognizerStateEnded) {
        return;
    }
    
    UITextView *textView = (UITextView *)tapGesture.view;
    CGPoint tapLocation = [tapGesture locationInView:textView];
    UITextPosition *textPosition = [textView closestPositionToPoint:tapLocation];
    NSDictionary *attributes = [textView textStylingAtPosition:textPosition inDirection:UITextStorageDirectionForward];
    
    NSURL *url = attributes[NSLinkAttributeName];
    
    if (url) {
        [[UIApplication sharedApplication] openURL:url];
    }
}

- (BOOL)textView:(UITextView *)textView shouldInteractWithURL:(NSURL *)URL inRange:(NSRange)characterRange {

    return YES;
}

- (void)viewWillAppear:(BOOL)animated{
    [super viewWillAppear:animated];
    [self setImageToBackground:self.imageBackground];
}


@end
