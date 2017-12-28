package nta.med.service.ihis.handler.xrts;

import nta.med.common.util.type.Tuple;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.config.Configuration;
import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.inv.*;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.Language;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.cpl.Cpl2010Repository;
import nta.med.data.dao.medi.inv.*;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.data.dao.medi.xrt.Xrt0202Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.data.model.ihis.ocso.PrOcsIudBomOrderActInfo;
import nta.med.data.model.ihis.ocso.PrOcsLoadSubulSuryangInfo;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.XrtsModelProto.XRT0201U00GrdJaeryoItemInfo;
import nta.med.service.ihis.proto.XrtsModelProto.XRT0201U00GrdOrderItemInfo;
import nta.med.service.ihis.proto.XrtsServiceProto;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

@Service
@Scope("prototype")
@Transactional
public class XRT0201U00SaveLayoutHandler extends ScreenHandler<XrtsServiceProto.XRT0201U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(XRT0201U00SaveLayoutHandler.class);
    @Resource
    private Ocs1003Repository ocs1003Repository;
    @Resource
    private Ocs2003Repository ocs2003Repository;
    @Resource
    private Xrt0202Repository xrt0202Repository;
    @Resource
    private Cpl2010Repository cpl2010Repository;
    @Resource
    private Inv1001Repository inv1001Repository;
    @Resource
    private Ocs0103Repository ocs0103Repository;
    @Resource
    private CommonRepository commonRepository;
    @Resource
    private Bas0102Repository bas0102Repository;
    @Resource
    private Inv0001Repository inv0001Repository;
    @Resource
    private Inv2003Repository inv2003Repository;
    @Resource
    private Inv2004Repository inv2004Repository;
    @Resource
    private Adm3200Repository adm3200Repository;
    @Resource
    private Inv0110Repository inv0110Repository;
    @Resource
    private Inv4001Repository inv4001Repository;
    @Resource
    private Inv4002Repository inv4002Repository;
    @Resource
    private Inv0102Repository inv0102Repository;
    @Resource
    private Bas0001Repository bas0001Repository;
    @Resource
    private Configuration configuration;
    
    private void insertINV1001(XRT0201U00GrdJaeryoItemInfo info, String userId, Double pkinv1001, String bunho,
                               Date orderDate, String inOutGubun, String jundalPart, Double subulSuryang, String subulDanui, Double pkocsInv, Double fkOcsXrt, String ioGubun, String hospitalCode) {
        Inv1001 inv1001 = new Inv1001();
        inv1001.setSysDate(new Date());
        inv1001.setSysId(userId);
        inv1001.setUpdDate(new Date());
        inv1001.setPkinv1001(pkinv1001);
        inv1001.setBunho(bunho);
        inv1001.setOrderDate(orderDate);
        inv1001.setInOutGubun(inOutGubun);
        inv1001.setInputPart(jundalPart);
        inv1001.setHangmogCode(info.getJaeryoCode());
        inv1001.setJaeryoCode(info.getJaeryoCode());
        inv1001.setSubulBuseo(jundalPart);
        inv1001.setSuryang(subulSuryang);
        inv1001.setDvTime("*");
        inv1001.setDv(new Double(1));
        inv1001.setNalsu(StringUtils.isEmpty(info.getNalsu()) ? new Double(1) : CommonUtils.parseDouble(info.getNalsu()));
        inv1001.setOrdDanui(subulDanui);
        inv1001.setActingDate(new Date());
        inv1001.setActBuseo(jundalPart);
        if ("I".equalsIgnoreCase(ioGubun)) {
            inv1001.setFkocs2003(pkocsInv);
        } else {
            inv1001.setFkocs1003(pkocsInv);
        }
        inv1001.setBomSourceKey(fkOcsXrt);
        inv1001.setHospCode(hospitalCode);
        inv1001Repository.save(inv1001);
    }

    @SuppressWarnings("finally")
    private Tuple<Integer, String> updJaeryoProcess(XrtsServiceProto.XRT0201U00SaveLayoutRequest request, String hospitalCode, String language, boolean isHosCodeInv, String churiTime) {
        Tuple<Integer, String> result = new Tuple<>(null, null);
        for (XRT0201U00GrdJaeryoItemInfo infoJaeryo : request.getGrdJaeryoItemInfoList()) { //start for XRT0201U00GrdJaeryoItemInfo
            if (DataRowState.ADDED.getValue().equals(infoJaeryo.getDataRowState())) {
                Double pkocsInv = null;
                String inputPart = request.getGrdOrderCurrentRow().getJundalPart();
                Date orderDate = DateUtil.toDate(request.getGrdOrderCurrentRow().getOrderDate(), DateUtil.PATTERN_YYMMDD);
                Double bomSourceKey = CommonUtils.parseDouble(request.getGrdOrderCurrentRow().getPkocs());
                Double pkOcs = new Double(0);
                Double suryang = CommonUtils.parseDouble(infoJaeryo.getSuryang());
                Date actingDate = DateUtil.toDate(request.getGrdOrderCurrentRow().getActingDate(), DateUtil.PATTERN_YYMMDD);
                String actingTime = request.getGrdOrderCurrentRow().getActingTime();
                Double nalsu = StringUtils.isEmpty(infoJaeryo.getNalsu()) ? new Double(1) : CommonUtils.parseDouble(infoJaeryo.getNalsu());

                if ("I".equalsIgnoreCase(request.getGrdOrderCurrentRow().getInOutGubun())) { //start check equal I
                    PrOcsIudBomOrderActInfo prResult = ocs2003Repository.callPrOcsIudBomInpOrderAct(hospitalCode, language,
                            "I", request.getUserId(), inputPart, orderDate, bomSourceKey,
                            pkOcs, infoJaeryo.getJaeryoCode(), suryang, actingDate, actingTime, null, nalsu, infoJaeryo.getOrdDanui());
                    if (prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())) {
                        result.setV2(prResult.getIoErrMsg());
                        return result;
                    }
                    //insert ocskey
                    if (prResult != null) {
                        pkocsInv = prResult.getIoPkocs2003();
                    }
                    //PR_OCS_LOAD_SUBUL_SURYANG
                    Integer orderSuyang = CommonUtils.parseInteger(infoJaeryo.getSuryang());
                    String gubun = request.getGrdOrderCurrentRow().getInOutGubun();
                    PrOcsLoadSubulSuryangInfo prOcsSuryang = ocs0103Repository.callPrOcsLoadSubulSuryang(hospitalCode, gubun, infoJaeryo.getJaeryoCode(),
                            infoJaeryo.getOrdDanui(), new Integer(1), "*", orderSuyang, new Integer(1), new Date());
                    if (prOcsSuryang != null && !"0".equalsIgnoreCase(prOcsSuryang.getoFlag())) {
                        return result;
                    }
                    // inv1001 save
                    String subulDanui = null;
                    Double subulSuryang = null;
                    if (prOcsSuryang != null) {
                        subulDanui = prOcsSuryang.getSubulDanui() == null ? infoJaeryo.getOrdDanui() : prOcsSuryang.getSubulDanui();
                        subulSuryang = prOcsSuryang.getSubulSuryang() == null ? new Double(1) : prOcsSuryang.getSubulSuryang().doubleValue();
                    }
                    Double pkinv1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV1001_SEQ"));
                    if (pkinv1001 != null) {
                        String bunho = request.getGrdOrderCurrentRow().getBunho();
                        String inOutGubun = request.getGrdOrderCurrentRow().getInOutGubun();
                        String jundalPart = request.getGrdOrderCurrentRow().getJundalPart();
                        Double fkOcsXrt = CommonUtils.parseDouble(request.getGrdOrderCurrentRow().getPkocs());
                        insertINV1001(infoJaeryo, request.getUserId(), pkinv1001, bunho, orderDate, inOutGubun, jundalPart,
                                subulSuryang, subulDanui, pkocsInv, fkOcsXrt, request.getGrdOrderCurrentRow().getInOutGubun(), hospitalCode);
                        result.setV1(1);
                    }
                } else { // else equal I
                    PrOcsIudBomOrderActInfo prResult = ocs1003Repository.callPrOcsIudBomOutOrderAct(hospitalCode, language,
                            "I", request.getUserId(), inputPart, bomSourceKey,
                            pkOcs, infoJaeryo.getJaeryoCode(), suryang, actingDate, actingTime, null, nalsu, infoJaeryo.getOrdDanui());
                    if (prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())) {
                        result.setV2(prResult.getIoErrMsg());
                        return result;
                    }
                    //insert ocskey
                    if (prResult != null) {
                        pkocsInv = prResult.getIoPkocs2003();
                    }
                    //PR_OCS_LOAD_SUBUL_SURYANG
                    Integer orderSuyang = CommonUtils.parseInteger(infoJaeryo.getSuryang());
                    String gubun = request.getGrdOrderCurrentRow().getInOutGubun();
                    PrOcsLoadSubulSuryangInfo prOcsSuryang = ocs0103Repository.callPrOcsLoadSubulSuryang(hospitalCode, gubun, infoJaeryo.getJaeryoCode(),
                            infoJaeryo.getOrdDanui(), new Integer(1), "*", orderSuyang, new Integer(1), new Date());
                    if (prOcsSuryang != null && !"0".equalsIgnoreCase(prOcsSuryang.getoFlag())) {
                        return result;
                    }
                    // inv1001 save
                    String subulDanui = null;
                    Double subulSuryang = null;
                    if (prOcsSuryang != null) {
                        subulDanui = prOcsSuryang.getSubulDanui() == null ? infoJaeryo.getOrdDanui() : prOcsSuryang.getSubulDanui();
                        subulSuryang = prOcsSuryang.getSubulSuryang() == null ? new Double(1) : prOcsSuryang.getSubulSuryang().doubleValue();
                    }
                    Double pkinv1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV1001_SEQ"));
                    if (pkinv1001 != null) {
                        String bunho = request.getGrdOrderCurrentRow().getBunho();
                        String inOutGubun = request.getGrdOrderCurrentRow().getInOutGubun();
                        String jundalPart = request.getGrdOrderCurrentRow().getJundalPart();
                        Double fkOcsXrt = CommonUtils.parseDouble(request.getGrdOrderCurrentRow().getPkocs());
                        insertINV1001(infoJaeryo, request.getUserId(), pkinv1001, bunho, orderDate, inOutGubun, jundalPart,
                                subulSuryang, subulDanui, pkocsInv, fkOcsXrt, request.getGrdOrderCurrentRow().getInOutGubun(), hospitalCode);
                        result.setV1(1);
                    }
                } //end equal I
                
                // logic inventoty
                String hangmogInventoryYn = inv0110Repository.checkInvenByJaeryCode(infoJaeryo.getJaeryoCode(), hospitalCode);
                if(isHosCodeInv && YesNo.YES.getValue().equals(hangmogInventoryYn)){
                	//Double ipgoQty = CommonUtils.parseDouble(infoJaeryo.getSuryang()) * CommonUtils.parseDouble("1") * CommonUtils.parseDouble("1");
                	Double ipgoQty = commonRepository.callFnDrgWonyoiTotSurang(CommonUtils.parseDouble("1"), CommonUtils.parseDouble(infoJaeryo.getSuryang()), CommonUtils.parseDouble("1"), "*");
                	inventoryHistoryCaseTick(hospitalCode, request.getUserId(), infoJaeryo.getJaeryoCode(), ipgoQty, null, language, churiTime);
                }
            } else if (DataRowState.MODIFIED.getValue().equals(infoJaeryo.getDataRowState())) {
                Integer orderSuyang = CommonUtils.parseInteger(infoJaeryo.getSuryang());
                String gubun = request.getGrdOrderCurrentRow().getInOutGubun();
                PrOcsLoadSubulSuryangInfo prOcsSuryang = ocs0103Repository.callPrOcsLoadSubulSuryang(hospitalCode, gubun, infoJaeryo.getJaeryoCode(),
                        infoJaeryo.getOrdDanui(), new Integer(1), "*", orderSuyang, new Integer(1), new Date());
                if (prOcsSuryang != null && !"0".equalsIgnoreCase(prOcsSuryang.getoFlag())) {
                    return result;
                }
                String subulDanui = null;
                Double subulSuryang = null;
                if (prOcsSuryang != null) {
                    subulDanui = prOcsSuryang.getSubulDanui() == null ? infoJaeryo.getOrdDanui() : prOcsSuryang.getSubulDanui();
                    subulSuryang = prOcsSuryang.getSubulSuryang() == null ? new Double(1) : prOcsSuryang.getSubulSuryang().doubleValue();
                }
                // update inv1001
                Double pkinv1001 = CommonUtils.parseDouble(infoJaeryo.getPkinv1001());
                Double nalsu = infoJaeryo.getNalsu() == null ? new Double(1) : CommonUtils.parseDouble(infoJaeryo.getNalsu());
                result.setV1(inv1001Repository.updateInv1001(hospitalCode, request.getUserId(), infoJaeryo.getJaeryoCode(), subulSuryang, subulDanui, nalsu, pkinv1001));

                Double bomSourceKey = CommonUtils.parseDouble(infoJaeryo.getFkocsXrt());
                Double pkOcs2003 = CommonUtils.parseDouble(infoJaeryo.getFkocsInv());
                String inputPart = request.getGrdOrderCurrentRow().getJundalPart();
                Date actingDate = DateUtil.toDate(request.getGrdOrderCurrentRow().getActingDate(), DateUtil.PATTERN_YYMMDD);
                String actingTime = request.getGrdOrderCurrentRow().getActingTime();
                if (bomSourceKey != null && pkOcs2003 != null) {
                    Double suryang = CommonUtils.parseDouble(infoJaeryo.getSuryang());
                    PrOcsIudBomOrderActInfo prResult = null;
                    if ("I".equalsIgnoreCase(request.getGrdOrderCurrentRow().getInOutGubun())) {
                        Date orderDate = DateUtil.toDate(request.getGrdOrderCurrentRow().getOrderDate(), DateUtil.PATTERN_YYMMDD);
                        Double nalsucaseIf = CommonUtils.parseDouble(infoJaeryo.getNalsu());
                        prResult = ocs2003Repository.callPrOcsIudBomInpOrderAct(hospitalCode, language,
                                "U", request.getUserId(), inputPart, orderDate, bomSourceKey,
                                pkOcs2003, infoJaeryo.getJaeryoCode(), suryang, actingDate, actingTime, null, nalsucaseIf, infoJaeryo.getOrdDanui());
                    } else {
                        prResult = ocs1003Repository.callPrOcsIudBomOutOrderAct(hospitalCode, language,
                                "U", request.getUserId(), inputPart, bomSourceKey,
                                pkOcs2003, infoJaeryo.getJaeryoCode(), suryang, actingDate, actingTime, null, nalsu, infoJaeryo.getOrdDanui());
                    }
                    if (prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())) {
                        result.setV2(prResult.getIoErrMsg());
                        return result;
                    }
                }
            } else if (DataRowState.DELETED.getValue().equals(infoJaeryo.getDataRowState())) {
                Double pkinv1001 = CommonUtils.parseDouble(infoJaeryo.getPkinv1001());
                result.setV1(inv1001Repository.deleteINV1001ByPkinv1001(hospitalCode, pkinv1001));
                Double bomSourceKey = CommonUtils.parseDouble(infoJaeryo.getFkocsXrt());
                Double pkOcs2003 = CommonUtils.parseDouble(infoJaeryo.getFkocsInv());
                String inputPart = request.getGrdOrderCurrentRow().getJundalPart();
                if (bomSourceKey != null && pkOcs2003 != null) {
                    Double suryang = CommonUtils.parseDouble(infoJaeryo.getSuryang());
                    Double nalsu = CommonUtils.parseDouble(infoJaeryo.getNalsu());
                    PrOcsIudBomOrderActInfo prResult = null;
                    if ("I".equalsIgnoreCase(request.getGrdOrderCurrentRow().getInOutGubun())) {
                        Date orderDate = DateUtil.toDate(request.getGrdOrderCurrentRow().getOrderDate(), DateUtil.PATTERN_YYMMDD);
                        prResult = ocs2003Repository.callPrOcsIudBomInpOrderAct(hospitalCode, language,
                                "D", request.getUserId(), inputPart, orderDate, bomSourceKey,
                                pkOcs2003, infoJaeryo.getJaeryoCode(), suryang, null, null, null, nalsu, infoJaeryo.getOrdDanui());
                    } else {
                        prResult = ocs1003Repository.callPrOcsIudBomOutOrderAct(hospitalCode, language,
                                "D", request.getUserId(), inputPart, bomSourceKey,
                                pkOcs2003, infoJaeryo.getJaeryoCode(), suryang, null, null, null, nalsu, infoJaeryo.getOrdDanui());
                    }
                    if (prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())) {
                        result.setV2(prResult.getIoErrMsg());
                        return result;
                    }
                }
            }
        }//end for XRT0201U00GrdJaeryoItemInfo
        return result;
    }

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, XrtsServiceProto.XRT0201U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        Integer result = null;
        String ioErrMsg = null;
        String hospitalCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        String userId = getUserId(vertx, sessionId);
     // check hospital using inventory or not
        List<ComboListItemInfo> combos = bas0102Repository.getComboListItemInfoByCodeType(hospitalCode, language, "INV_USAGE");
        boolean isHosCodeInv = combos.size() > 0 && "Y".equals(combos.get(0).getCode());
//		get local time zone
		Integer localTimeZone = getTimeZone(vertx, sessionId);
		if(localTimeZone == null){
			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(hospitalCode);
			if (!CollectionUtils.isEmpty(bas0001List)) {
				Bas0001 bas0001 = bas0001List.get(0);
				localTimeZone = bas0001.getTimeZone() != null ? bas0001.getTimeZone() : configuration.getDefaultTimeZone();
			} else{
				localTimeZone = configuration.getDefaultTimeZone();
			}
		}
		int defaultTimeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;		
		Date sysDate = CommonUtils.getLocalDateTime(defaultTimeZone, localTimeZone);
		SimpleDateFormat localDateFormat = new SimpleDateFormat("HHmm");
		String churiTime = localDateFormat.format(sysDate);
        try {
            //getJaeryoCode == getHangmocCode
            //A . FOREACH grdOrder
            for (XRT0201U00GrdOrderItemInfo info : request.getGrdOrderItemInfoList()) { //start for XRT0201U00GrdOrderItemInfo
                if (DataRowState.MODIFIED.getValue().equals(info.getDataRowState())) {
                    List<String> list = new ArrayList<String>();
                    if ("O".equalsIgnoreCase(info.getInOutGubun())) {
                        list = ocs1003Repository.getIfDataSendYnOCS1003(hospitalCode, CommonUtils.parseDouble(info.getPkocs()));

                    } else {
                        list = ocs2003Repository.getIfDataSendYnOCS2003(hospitalCode, CommonUtils.parseDouble(info.getPkocs()));
                    }
                    String getYN = null;
                    if (!CollectionUtils.isEmpty(list)) {
                        getYN = list.get(0);
                    }
                    Boolean locationCheck = false;
                    if(getLanguage(vertx, sessionId).equals(Language.VIETNAMESE.toString().toUpperCase())){
                    	locationCheck = true;
                    } else {
                    	locationCheck  = !"Y".equalsIgnoreCase(getYN);
                    }
                    if (locationCheck) { //start check equal value from XRT0201U00DataSendYnHandler
                        if (request.getRbxJubsu()) { //start rbxJubsu.Checked
                            if ("Y".equalsIgnoreCase(info.getJubsuYn())) {
                                Double fkOcs = CommonUtils.parseDouble(info.getPkocs());
                                Date jubsuDate = DateUtil.toDate(info.getJubsuDate(), DateUtil.PATTERN_YYMMDD);
                                ocs1003Repository.callPrOcsUpdateXrtJubsu(hospitalCode, info.getInOutGubun(), fkOcs,
                                        request.getUserId(), jubsuDate, info.getJubsuTime(), info.getActDoctor());
                                if ("Y".equalsIgnoreCase(request.getUseRadioYn())) {
                                    String inOutGubun = request.getGrdPaListCurrentRow().getInOutGubun();
                                    xrt0202Repository.callPRXrtManagementXrt0202(hospitalCode, "I", fkOcs, info.getActDoctor(), inOutGubun);
                                }
                                result = 1;
                            }
                        } //end rbxJubsu.Checked

                        if (request.getRbxAct()) {//start rbxAct.Checked
                            if ("N".equalsIgnoreCase(info.getJubsuYn()) && "N".equalsIgnoreCase(info.getActYn())) { //start check equal N
                                Double fkOcs = CommonUtils.parseDouble(info.getPkocs());
                                ocs1003Repository.callPrOcsUpdateXrtJubsu(hospitalCode, info.getInOutGubun(), fkOcs,
                                        request.getUserId(), null, null, null);
                                if ("Y".equalsIgnoreCase(request.getUseRadioYn())) {
                                    String inOutGubun = request.getGrdPaListCurrentRow().getInOutGubun();
                                    xrt0202Repository.callPRXrtManagementXrt0202(hospitalCode, "D", fkOcs, "", inOutGubun);
                                }
                                result = 1; //if execute pr dont have  error then set result = 1 so it will reponse true otherwise response false
                            } //end check equal N

                            if ("Y".equalsIgnoreCase(info.getJubsuYn()) && "Y".equalsIgnoreCase(info.getActYn())) { //start check equal Y
                                Date actingDate = DateUtil.toDate(info.getActingDate(), DateUtil.PATTERN_YYMMDD);
                                Double fkOcs = CommonUtils.parseDouble(info.getPkocs());
                                ocs1003Repository.callPrOcsUpdateXrtAacting(hospitalCode, info.getInOutGubun(), fkOcs, request.getUserId(),
                                        info.getActBuseo(), actingDate, info.getActingTime(), info.getActingDate(), info.getXrtDrYn());
                                cpl2010Repository.callCPL2010U00PrSchUpdateActing(hospitalCode, info.getInOutGubun(), fkOcs, actingDate);
                                result = 1; //if execute pr dont have error then set result = 1 so it will reponse true otherwise response false
                            } //end check equal Y
                        }// end rbxAct.Checked

                        if (request.getRbxActEnd()) {//start rbxActEnd.Checked
                            if ("Y".equalsIgnoreCase(info.getJubsuYn()) && "N".equalsIgnoreCase(info.getActYn())) { //start check equal Y and N
                            	Date actingDate = null;
                                Double fkOcs = CommonUtils.parseDouble(info.getPkocs());
                                ocs1003Repository.callPrOcsUpdateXrtAacting(hospitalCode, info.getInOutGubun(), fkOcs, request.getUserId(),
                                        null, null, null, null, null);
                                cpl2010Repository.callCPL2010U00PrSchUpdateActing(hospitalCode, info.getInOutGubun(), fkOcs, actingDate);

                                //updJaeryoProcess("D");
                                for (XRT0201U00GrdJaeryoItemInfo infoJaeryo : request.getGrdJaeryoItemInfoList()) { //start for OCSACTUpdJaeryoProcessWithUpdGubunInfo
                                    Double pkinv1001 = CommonUtils.parseDouble(infoJaeryo.getPkinv1001());
                                    result = inv1001Repository.deleteINV1001ByPkinv1001(hospitalCode, pkinv1001);
                                    Double bomSourceKey = CommonUtils.parseDouble(infoJaeryo.getFkocsXrt());
                                    Double pkOcs2003 = CommonUtils.parseDouble(infoJaeryo.getFkocsInv());
                                    if (bomSourceKey != null && pkOcs2003 != null) {
                                        Double suryang = CommonUtils.parseDouble(infoJaeryo.getSuryang());
                                        Double nalsu = CommonUtils.parseDouble(infoJaeryo.getNalsu());
                                        PrOcsIudBomOrderActInfo prResult = null;
                                        if ("I".equalsIgnoreCase(info.getInOutGubun())) {
                                            Date orderDate = DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD);
                                            prResult = ocs2003Repository.callPrOcsIudBomInpOrderAct(hospitalCode, language,
                                                    "D", request.getUserId(), info.getJundalPart(), orderDate, bomSourceKey,
                                                    pkOcs2003, infoJaeryo.getJaeryoCode(), suryang, null, null, null, nalsu, infoJaeryo.getOrdDanui());
                                        } else {
                                            prResult = ocs1003Repository.callPrOcsIudBomOutOrderAct(hospitalCode, language,
                                                    "D", request.getUserId(), info.getJundalPart(), bomSourceKey,
                                                    pkOcs2003, infoJaeryo.getJaeryoCode(), suryang, null, null, null, nalsu, infoJaeryo.getOrdDanui());
                                        }
                                        if (prResult != null && !"0".equalsIgnoreCase(prResult.getIoErr())) {
                                            ioErrMsg = prResult.getIoErrMsg();
                                            response.setResult(false);
                                            response.setMsg(ioErrMsg);
                                            throw new ExecutionException(response.build());
                                        }
                                    }
                                }//end for OCSACTUpdJaeryoProcessWithUpdGubunInfo
                            }//end check equal Y and N
                        }// end rbxActEnd.Checked
                    } //end check equal value from XRT0201U00DataSendYnHandler
                }
            } //end for XRT0201U00GrdOrderItemInfo
            //B. rbxAct.Checked
            if (request.getRbxAct()) {
                if ("Y".equalsIgnoreCase(request.getGrdOrderCurrentRow().getJubsuYn()) && request.getRbxActUpdJaeryoYn()) {
                    Tuple<Integer, String> retVal = updJaeryoProcess(request, hospitalCode, language, isHosCodeInv, churiTime);
                    if(retVal.getV2() != null){
                        response.setResult(false);
                        response.setMsg(retVal.getV2());
                        throw new ExecutionException(response.build());
                    }
                    result = retVal.getV1();
                    ioErrMsg = retVal.getV2();
                } else {
                    result = 1; //if check case if false then set result = 1 so it will response true otherwise response false
                }
            }

            //C. rbxActEnd.Checked
            if (request.getRbxActEnd()) {
                String currentJubsuYn = request.getGrdOrderCurrentRow().getJubsuYn();
                String currentActYn = request.getGrdOrderCurrentRow().getActYn();
                if ("Y".equalsIgnoreCase(currentJubsuYn) && "Y".equalsIgnoreCase(currentActYn) && request.getRbxActEndUpdJaeryoYn()) {
                    Tuple<Integer, String> retVal = updJaeryoProcess(request, hospitalCode, language, isHosCodeInv, churiTime);
                    if(retVal.getV2() != null){
                        response.setResult(false);
                        response.setMsg(retVal.getV2());
                        throw new ExecutionException(response.build());
                    }
                    result = retVal.getV1();
                    ioErrMsg = retVal.getV2();
                } else {
                    result = 1; //if check case if false then set result = 1 so it will response true otherwise response false
                }
            }
        } finally {
            if (!StringUtils.isEmpty(ioErrMsg)) {
                response.setMsg(ioErrMsg);
            }
            if (result == null) {
                response.setResult(false);
            } else {
                response.setResult(true);
            }
        }
        return response.build();
    }
    
    private void inventoryHistoryCaseTick(String hospCode, String userId,
			String jaeryoCode, Double chulgoQty, Double fkocs1003, String language, String churiTime){
		Double pkinv2003 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2003_SEQ"));
        Double pkinv2004 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2004_SEQ"));
        
        String churiBuseo = "";
		List<Adm3200> adm3200s = adm3200Repository.getAdm3200ByUserId(hospCode, userId);
		if(!CollectionUtils.isEmpty(adm3200s)){
			churiBuseo = adm3200s.get(0).getDeptCode();
		}
		Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("CHURI_SEQ"));
		 
		inv0001Repository.updateInv0001(userId, new BigDecimal("0"), hospCode, fkocs1003);
		String remark = ocs1003Repository.getRemarkOcs1003(hospCode, fkocs1003, null, language);
		
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String exportCode = CollectionUtils.isEmpty(listCodeName) ? String.valueOf(churiSeq).split("\\.")[0] : listCodeName.get(0) + String.valueOf(churiSeq).split("\\.")[0];
		
		Inv2003 inv2003 = new Inv2003();
		inv2003.setSysDate(new Date());
		inv2003.setSysId(userId);
		inv2003.setUpdDate(new Date());
		inv2003.setUpdId(userId);
		inv2003.setHospCode(hospCode);
		inv2003.setChuriDate(new Date());
		inv2003.setChuriBuseo(churiBuseo);
		inv2003.setChulgoType("ORD");
		inv2003.setChuriSeq(churiSeq);
		inv2003.setPkinv2003(pkinv2003);
		inv2003.setIpchulType("O");
		inv2003.setRemark(remark);
		inv2003.setExportCode(exportCode);
		inv2003.setChuriTime(churiTime);
		
		inv2003Repository.save(inv2003);
		
		Inv2004 inv2004 = new Inv2004();
		inv2004.setSysDate(new Date());
		inv2004.setSysId(userId);
		inv2004.setUpdDate(new Date());
		inv2004.setHospCode(hospCode);
		inv2004.setFkinv2003(pkinv2003);
		inv2004.setJaeryoCode(jaeryoCode);
		inv2004.setChulgoQty(chulgoQty);
		inv2004.setPkinv2004(pkinv2004);
		inv2004Repository.save(inv2004);
	}
    
    private void inventoryHistoryCaseUnTick(String hospCode, String userId, 
			Double ipgoQty, Double fkocs1003, String jaeryoCode, String language){
		
		Double pkinv4001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4001_SEQ"));
        Double pkinv4002 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4002_SEQ"));
        
        String churiBuseo = "";
		List<Adm3200> adm3200s = adm3200Repository.getAdm3200ByUserId(hospCode, userId);
		if(!CollectionUtils.isEmpty(adm3200s)){
			churiBuseo = adm3200s.get(0).getDeptCode();
		}
        
        Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("CHURI_SEQ"));
        String remark = ocs1003Repository.getRemarkOcs1003(hospCode, fkocs1003, null, language);
        
		inv0001Repository.updateInv0001(userId, new BigDecimal("1"), hospCode, fkocs1003);
		
		Inv4001 inv4001 = new Inv4001();
		inv4001.setSysDate(new Date());
		inv4001.setSysId(userId);
		inv4001.setUpdDate(new Date());
		inv4001.setUpdId(userId);
		inv4001.setHospCode(hospCode);
		inv4001.setChuriDate( new Date());
		inv4001.setChuriBuseo(churiBuseo);
		inv4001.setIpgoType("RET");
		inv4001.setChuriSeq(churiSeq);
		inv4001.setIpchulType("I");
		inv4001.setPkinv4001(pkinv4001);
		inv4001.setRemark(remark);
		inv4001Repository.save(inv4001);
		
		Inv4002 inv4002 = new Inv4002();
		inv4002.setSysDate(new Date());
		inv4002.setSysId(userId);
		inv4002.setUpdDate(new Date());
		inv4002.setUpdId(userId);
		inv4002.setHospCode(hospCode);
		inv4002.setFkinv4001(pkinv4001);
		inv4002.setJaeryoCode(jaeryoCode);
		inv4002.setIpgoQty(ipgoQty);
		inv4002.setPkinv4002(pkinv4002);
		inv4002.setLot("10");
		inv4002.setExpiredDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
		inv4002Repository.save(inv4002);
	}
}