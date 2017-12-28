package nta.med.service.ihis.handler.ocsa;

import java.util.Arrays;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.time.DateUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inv.Inv0110;
import nta.med.core.domain.ocs.Ocs0103;
import nta.med.core.domain.ocs.Ocs0108;
import nta.med.core.domain.ocs.Ocs0113;
import nta.med.core.domain.ocs.Ocs0115;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.glossary.OrderGubun;
import nta.med.core.glossary.UserRole;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.clis.ClisProtocolRepository;
import nta.med.data.dao.medi.ifs.Ifs0003Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.dao.medi.ocs.Ocs0103SRepository;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.data.dao.medi.ocs.Ocs0113Repository;
import nta.med.data.dao.medi.ocs.Ocs0115Repository;
import nta.med.data.model.ihis.clis.CLIS2015U03ProtocolListInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0103U00GrdOCS0103Info;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0103U00GrdOCS0108Info;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0103U00GrdOCS0113Info;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0103U00GrdOCS0115Info;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class OCS0103U00SaveLayoutHandler
        extends ScreenHandler<OcsaServiceProto.OCS0103U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOGGER = LogFactory.getLog(OCS0103U00SaveLayoutHandler.class);

    @Resource
    private Ocs0103Repository ocs0103Repository;

    @Resource
    private Ocs0108Repository ocs0108Repository;

    @Resource
    private Ocs0115Repository ocs0115Repository;

    @Resource
    private Ocs0113Repository ocs0113Repository;

    @Resource
    private ClisProtocolRepository clisProtocolRepository;

    @Resource
    private Ocs0103SRepository ocs0103SRepository;

    @Resource
    private Bas0001Repository bas0001Repository;

    @Resource
    private Ifs0003Repository ifs0003Repository;
    
    @Resource
    private Inv0110Repository inv0110Repository;

    @Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId,
                          OCS0103U00SaveLayoutRequest request) throws Exception {
        if (UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
            setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
                    getLanguage(vertx, sessionId), "", 1));
        }
    }

    @Override
    public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
                                 OCS0103U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String hospCode = getHospitalCode(vertx, sessionId);
        String language = getLanguage(vertx, sessionId);
        List<String> listHosp = bas0001Repository.getHospCodeInGroup(hospCode);

        // repeated OCS0103U00GrdOCS0103Info grd_ocs0103_item = 2; // callerId =
        // 1;
        for (OCS0103U00GrdOCS0103Info info : request.getGrdOcs0103ItemList()) {

            Date startDate = DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD);
            List<Ocs0103> listOcs0103 = ocs0103Repository.getListOcs0103ByHangmogCodeAndStartDate(hospCode,
                    info.getHangmogCode(), startDate);

            Ocs0103 ocs1003 = listOcs0103.size() > 0 ? listOcs0103.get(0) : null;
            boolean isCommonOrder = "Y".equals(info.getCommonOrder())
                    || (ocs1003 != null && "Y".equals(ocs1003.getCommonOrder()));

            if (isCommonOrder && !isMappedToAccountingSystem(info.getHangmogCode(), listHosp, !DataRowState.ADDED.getValue().equals(info.getRowState()))) {
                throw new ExecutionException(response.setResult(false).setMsg("unmap").build());
            }

            Date startDateMinus1 = DateUtils.addDays(startDate, -1);
            CLIS2015U03ProtocolListInfo clisProtocolInfo = clisProtocolRepository
                    .getOCS0103U00GetNameProtocolInfo(hospCode, info.getProtocol());
            Integer clisProtoId = clisProtocolInfo == null ? null : clisProtocolInfo.getClisProtocolId();

            List<String> affectedHospCodes = isCommonOrder ? listHosp : Arrays.asList(hospCode);
            String orderGubun = info.getOrderGubun();
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                String getY = ocs0103Repository.getYOCS0103U00SaveLayout(hospCode, info.getHangmogCode(),
                        startDate);
                if ("Y".equalsIgnoreCase(getY)) {
                    response.setMsg("1");
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
                if((OrderGubun.C.getValue().equals(orderGubun) || OrderGubun.D.getValue().equals(orderGubun) || OrderGubun.K.getValue().equals(orderGubun)) 
                		&& StringUtils.isEmpty(info.getJaeryoCode())){
					Boolean isDuplicateKey = inv0110Repository.isExistedINV0110(hospCode, info.getHangmogCode());
					if (!isDuplicateKey) {
						insertInv0110(info, request.getUserId(), hospCode);
					}
                }
                addNewOCS0103(affectedHospCodes, info, request.getUserId(), startDateMinus1, startDate, clisProtoId, language);
                
            } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                modifyOCS0103(request, affectedHospCodes, info, startDate, clisProtoId);
                if((OrderGubun.C.getValue().equals(orderGubun) || OrderGubun.D.getValue().equals(orderGubun) 
                		|| OrderGubun.K.getValue().equals(orderGubun) || OrderGubun.B.getValue().equals(orderGubun)) 
                		&& !StringUtils.isEmpty(info.getJaeryoCode())){
                	String stockYn = "N";
                	Double subulDanga = null;
                	if((OrderGubun.C.getValue().equals(orderGubun) || OrderGubun.D.getValue().equals(orderGubun) || OrderGubun.K.getValue().equals(orderGubun)
                			&& YesNo.YES.getValue().equals(info.getWonnaeDrgYn()))){
                		stockYn = "Y";
                		subulDanga = new Double("0");
                	}
                	String jaeryoNameInx = info.getHangmogName() + " " + info.getHangmogCode();
                	inv0110Repository.updateInv0110ByJaeryoCode(info.getJaeryoName(), jaeryoNameInx, 
                		  info.getOrdDanui(), stockYn, subulDanga, startDate, "U", info.getJaeryoCode(), hospCode);
                }else if((OrderGubun.C.getValue().equals(orderGubun) || OrderGubun.D.getValue().equals(orderGubun) 
                		|| OrderGubun.K.getValue().equals(orderGubun) || OrderGubun.B.getValue().equals(orderGubun)) 
                		&& StringUtils.isEmpty(info.getJaeryoCode())){
                	Boolean isDuplicateKey = inv0110Repository.isExistedINV0110(hospCode, info.getHangmogCode());
					if (!isDuplicateKey) {
						insertInv0110(info, request.getUserId(), hospCode);
					}
                }
            } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                for (String objHospCode : affectedHospCodes) {
                    ocs0103Repository.deleteOcs0103U00(objHospCode, info.getHangmogCode());
                }
                if((OrderGubun.C.getValue().equals(orderGubun) || OrderGubun.D.getValue().equals(orderGubun) 
                		|| OrderGubun.K.getValue().equals(orderGubun) || OrderGubun.B.getValue().equals(orderGubun)) 
                		&& !StringUtils.isEmpty(info.getJaeryoCode())){
                	inv0110Repository.deleteInv0110ByJaeryoCode(info.getJaeryoCode(), hospCode);
                }
            }
        }
        // }

        // repeated OCS0103U00GrdOCS0108Info grd_ocs0108_item = 3; // callerId =
        // 2;
        for (OCS0103U00GrdOCS0108Info info : request.getGrdOcs0108ItemList()) {
            Date hangmogStartDate = DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                String getY = ocs0108Repository.checkExitYOcs0108(hospCode, info.getHangmogCode(), hangmogStartDate,
                        info.getOrdDanui());
                if ("Y".equalsIgnoreCase(getY)) {
                    response.setMsg("2");
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
                Double seq = ocs0108Repository.getMaxSeqOcs0108(hospCode, hangmogStartDate, info.getHangmogCode());
                if (seq == null) {
                    seq = new Double(1);
                }
                insertOCS0108(info, request.getUserId(), seq, hospCode);
            } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                ocs0108Repository.updateOCS0103U00(hospCode, CommonUtils.parseDouble(info.getSunabGijun()),
                        CommonUtils.parseDouble(info.getSubulGijun()), request.getUserId(), ModifyFlg.UPDATE.getValue(),
                        info.getHangmogCode(), hangmogStartDate, info.getOrdDanui());
            } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                ocs0108Repository.deleteOCS0108U00Execute(hospCode, info.getHangmogCode(), hangmogStartDate,
                        info.getOrdDanui());
            }
        }

        // repeated OCS0103U00GrdOCS0115Info grd_ocs0115_item = 4; // callerId =
        // 3;
        for (OCS0103U00GrdOCS0115Info info : request.getGrdOcs0115ItemList()) {
            Date hangmogStartDate = DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);
            Date startDate = DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD);
            Date startDateMinus1 = DateUtils.addDays(startDate, -1);
            Date endDate = DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD);
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                String getY = ocs0115Repository.checkExistYOcs0115(hospCode, info.getHangmogCode(), info.getInputPart(),
                        info.getInputGwa(), hangmogStartDate, startDate);
                if ("Y".equalsIgnoreCase(getY)) {
                    response.setMsg("3");
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
                ocs0115Repository.updateOcs0103U00Case3Add(hospCode, startDateMinus1, startDate,
                        request.getUserId(), info.getHangmogCode(), info.getInputPart(), info.getInputGwa(),
                        hangmogStartDate);
                insertOCS0115(info, request.getUserId(), hospCode);

            } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                ocs0115Repository.updateOcs0103U00Case3Modify(hospCode, request.getUserId(),
                        StringUtils.isEmpty(info.getJundalTableOut()) ? null : info.getJundalTableOut(),
                        StringUtils.isEmpty(info.getJundalPartOut()) ? null : info.getJundalPartOut(),
                        StringUtils.isEmpty(info.getJundalTableInp()) ? null : info.getJundalTableInp(),
                        StringUtils.isEmpty(info.getJundalPartInp()) ? null : info.getJundalPartInp(),
                        StringUtils.isEmpty(info.getMovePart()) ? null : info.getMovePart(), endDate, hangmogStartDate,
                        info.getHangmogCode(), info.getInputPart(), info.getInputGwa(), startDate);
            } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                ocs0115Repository.updateOcs0103U00Case3Deleted(hospCode, request.getUserId(),
                        info.getHangmogCode(), info.getInputPart(), info.getInputGwa(), hangmogStartDate,
                        startDateMinus1);
                ocs0115Repository.deleleOCS0103U00SaveLayout(hospCode, info.getHangmogCode(),
                        info.getInputPart(), info.getInputGwa(), hangmogStartDate, startDate);
            }
        }

        // repeated OCS0103U00GrdOCS0113Info grd_ocs0113_item = 5; // callerId =
        // 4;
        for (OCS0103U00GrdOCS0113Info info : request.getGrdOcs0113ItemList()) {
            Date hangmogStartDate = DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);
            if (DataRowState.ADDED.getValue().equals(info.getRowState())) {
                String getY = ocs0113Repository.getCheckYOcs0113(hospCode, info.getHangmogCode(), hangmogStartDate,
                        info.getSpecimenCode());
                if ("Y".equalsIgnoreCase(getY)) {
                    response.setMsg("4");
                    response.setResult(false);
                    throw new ExecutionException(response.build());
                }
                Double seq = ocs0113Repository.getMaxSeqOcs0113(hospCode, hangmogStartDate, info.getHangmogCode());
                if (seq == null) {
                    seq = new Double(1);
                }
                insertOCS0113(info, request.getUserId(), seq, hospCode);
            } else if (DataRowState.MODIFIED.getValue().equals(info.getRowState())) {
                ocs0113Repository.updateOCS0103U00SaveLayout(hospCode, info.getDefaultYn(),
                        request.getUserId(), info.getHangmogCode(), hangmogStartDate, info.getSpecimenCode());
            } else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
                ocs0113Repository.deleteOCS0103U00SaveLayout(hospCode, info.getHangmogCode(), hangmogStartDate,
                        info.getSpecimenCode());
            }
        }
        response.setResult(true);
        return response.build();
    }

    private void modifyOCS0103(OCS0103U00SaveLayoutRequest request, List<String> listHosp, OCS0103U00GrdOCS0103Info info, Date startDate, Integer clisProtoId) {
        List<Ocs0103> listOcs0103;
        for (String objHospCode : listHosp) {
        	listOcs0103 = ocs0103Repository.getListOcs0103ByHangmogCode(objHospCode, info.getHangmogCode());
            if (!CollectionUtils.isEmpty(listOcs0103)) {
                for (Ocs0103 ocs0103 : listOcs0103) {
                    ocs0103.setHangmogName(StringUtils.isEmpty(info.getHangmogName()) ? null : info.getHangmogName());
                    ocs0103.setSlipCode(StringUtils.isEmpty(info.getSlipCode()) ? null : info.getSlipCode());
                    ocs0103.setGroupYn(StringUtils.isEmpty(info.getGroupYn()) ? null : info.getGroupYn());
                    ocs0103.setPosition(StringUtils.isEmpty(info.getPosition()) ? null : info.getPosition());
                    //Fix bug MED-11995
                    //ocs0103.setOrderGubun(StringUtils.isEmpty(info.getOrderGubun()) ? "" : info.getOrderGubun());
                    ocs0103.setOrderGubun(StringUtils.isEmpty(info.getOrderGubun()) ? null : info.getOrderGubun());
                    ocs0103.setInputControl(StringUtils.isEmpty(info.getInputControl()) ? null : info.getInputControl());
                    ocs0103.setJundalTableOut(StringUtils.isEmpty(info.getJundalTableOut()) ? null : info.getJundalTableOut());
                    ocs0103.setJundalTableInp(StringUtils.isEmpty(info.getJundalTableInp()) ? null : info.getJundalTableInp());
                    ocs0103.setJundalPartOut(StringUtils.isEmpty(info.getJundalPartOut()) ? null : info.getJundalPartOut());
                    ocs0103.setJundalPartInp(StringUtils.isEmpty(info.getJundalPartInp()) ? null : info.getJundalPartInp());
                    ocs0103.setMovePart(StringUtils.isEmpty(info.getMovePart()) ? null : info.getMovePart());
                    ocs0103.setDvTime(StringUtils.isEmpty(info.getDvTime()) ? null : info.getDvTime());
                    ocs0103.setOrdDanui(StringUtils.isEmpty(info.getOrdDanui()) ? null : info.getOrdDanui());
                    ocs0103.setDefaultBogyongCode(StringUtils.isEmpty(info.getDefaultBogyongCode()) ? null : info.getDefaultBogyongCode());
                    ocs0103.setSugaYn(StringUtils.isEmpty(info.getSugaYn()) ? null : info.getSugaYn());
                    ocs0103.setSgCode(StringUtils.isEmpty(info.getSgCode()) ? null : info.getSgCode());
                    ocs0103.setJaeryoYn(StringUtils.isEmpty(info.getJaeryoYn()) ? null : info.getJaeryoYn());
                    ocs0103.setJaeryoCode(StringUtils.isEmpty(info.getJaeryoCode()) ? null : info.getJaeryoCode());
                    ocs0103.setHangmogNameInx(StringUtils.isEmpty(info.getHangmogNameInx()) ? null : info.getHangmogNameInx());
                    ocs0103.setDisplayYn(StringUtils.isEmpty(info.getDisplayYn()) ? null : info.getDisplayYn());
                    Date endDate = DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD);
                    ocs0103.setEndDate(endDate);
                    ocs0103.setSpecimenYn(StringUtils.isEmpty(info.getSpecimenYn()) ? null : info.getSpecimenYn());
                    ocs0103.setSpecimenDefault(StringUtils.isEmpty(info.getSpecimenDefault()) ? null : info.getSpecimenDefault());
                    ocs0103.setDefaultPortableYn(StringUtils.isEmpty(info.getDefaultPortableYn1()) ? null : info.getDefaultPortableYn1());
                    ocs0103.setSpecificComment(StringUtils.isEmpty(info.getSpecificComment()) ? null : info.getSpecificComment());
                    ocs0103.setReserYnOut(StringUtils.isEmpty(info.getReserYnOut()) ? null : info.getReserYnOut());
                    ocs0103.setReserYnInp(StringUtils.isEmpty(info.getReserYnInp()) ? null : info.getReserYnInp());
                    ocs0103.setEmergency(StringUtils.isEmpty(info.getEmergency()) ? null : info.getEmergency());
                    ocs0103.setLimitSuryang(CommonUtils.parseDouble(info.getLimitSuryang()));
                    ocs0103.setBomYn(StringUtils.isEmpty(info.getBomYn()) ? null : info.getBomYn());
                    ocs0103.setReturnYn(StringUtils.isEmpty(info.getReturnYn()) ? null : info.getReturnYn());
                    ocs0103.setSubulConvertGubun(StringUtils.isEmpty(info.getSubulConvertGubun()) ? null : info.getSubulConvertGubun());
                    ocs0103.setWonyoiOrderYn(StringUtils.isEmpty(info.getWonyoiOrderYn()) ? null : info.getWonyoiOrderYn());
                    ocs0103.setDefaultWonnaeSayu(StringUtils.isEmpty(info.getDefaultWonnaeSayu()) ? null : info.getDefaultWonnaeSayu());
                    ocs0103.setAntiCancerYn(StringUtils.isEmpty(info.getAntiCancerYn()) ? null : info.getAntiCancerYn());
                    ocs0103.setChisikYn(StringUtils.isEmpty(info.getChisikYn()) ? null : info.getChisikYn());
                    ocs0103.setNdayYn(StringUtils.isEmpty(info.getNdayYn()) ? null : info.getNdayYn());
                    ocs0103.setMuhyoYn(StringUtils.isEmpty(info.getMuhyoYn()) ? null : info.getMuhyoYn());
                    ocs0103.setInvJundalYn(StringUtils.isEmpty(info.getInvJundalYn()) ? null : info.getInvJundalYn());
                    ocs0103.setPowderYn(StringUtils.isEmpty(info.getPowderYn()) ? null : info.getPowderYn());
                    ocs0103.setRemark(StringUtils.isEmpty(info.getRemark()) ? null : info.getRemark());
                    ocs0103.setDefaultDv(CommonUtils.parseDouble(info.getDefaultDv()));
                    ocs0103.setDefaultSuryang(CommonUtils.parseDouble(info.getDefaultSuryang()));
                    ocs0103.setSgName(StringUtils.isEmpty(info.getSgName()) ? null : info.getSgName());
                    ocs0103.setNurseInputYn(StringUtils.isEmpty(info.getNurseInputYn()) ? null : info.getNurseInputYn());
                    ocs0103.setSupplyInputYn(StringUtils.isEmpty(info.getSupplyInputYn()) ? null : info.getSupplyInputYn());
                    ocs0103.setLimitNalsu(CommonUtils.parseDouble(info.getLimitNalsu()));
                    ocs0103.setDefaultWonyoiYn(StringUtils.isEmpty(info.getDefaultWonyoiYn()) ? null : info.getDefaultWonyoiYn());
                    ocs0103.setPortableCheck(StringUtils.isEmpty(info.getPortableCheck()) ? null : info.getPortableCheck());
                    ocs0103.setPatStatusGr(StringUtils.isEmpty(info.getPatStatusGr()) ? null : info.getPatStatusGr());
                    ocs0103.setUpdDate(new Date());
                    ocs0103.setUpdId(StringUtils.isEmpty(request.getUserId()) ? null : request.getUserId());
                    ocs0103.setDefaultJusa(StringUtils.isEmpty(info.getDefaultJusa()) ? null : info.getDefaultJusa());
                    ocs0103.setIfInputControl(StringUtils.isEmpty(info.getIfInputControl()) ? null : info.getIfInputControl());
                    ocs0103.setResultGubun(StringUtils.isEmpty(info.getResultGubun()) ? null : info.getResultGubun());
                    ocs0103.setWonnaeDrgYn(StringUtils.isEmpty(info.getWonnaeDrgYn()) ? null : info.getWonnaeDrgYn());
                    // ocs0103.setOutHospBookYn(StringUtils.isEmpty(info.getOutHospBookYn())
                    // ? null : info.getOutHospBookYn());
                    ocs0103.setYjCode(StringUtils.isEmpty(info.getYjCode()) ? null : info.getYjCode());
                    ocs0103.setTrialFlg(StringUtils.isEmpty(info.getTrial()) ? null : info.getTrial());
                    ocs0103.setClisProtocolId(StringUtils.isEmpty(clisProtoId) ? null : clisProtoId);
                    ocs0103.setModifyFlg(ModifyFlg.UPDATE.getValue());
                    ocs0103.setCommonOrder(info.getCommonOrder());

                    ocs0103.setHospCode(objHospCode);
                }
                ocs0103Repository.save(listOcs0103);
            }
        }
    }

    private void addNewOCS0103(List<String> hospCodes, OCS0103U00GrdOCS0103Info info, String userId, Date startDateMinus1, Date startDate, Integer clisProtoId, String language) {
        for (String hospCode : hospCodes) {
            ocs0103Repository.updateOCS0103U00(hospCode, userId, startDateMinus1, ModifyFlg.UPDATE.getValue(), startDate, info.getHangmogCode());
            Double seq = ocs0103Repository.getMaxSeqOcs0103(hospCode, info.getSlipCode());
            if (seq == null) {
                seq = new Double(1);
            }
            insertOCS0103(info, userId, seq, hospCode, clisProtoId, language);
        }
    }

    private void insertOCS0103(OCS0103U00GrdOCS0103Info info, String userId, Double seq, String hospCode,
                               Integer protocolId, String language) {
        Ocs0103 ocs0103 = new Ocs0103();
        ocs0103.setSysDate(new Date());
        ocs0103.setSysId(userId);
        ocs0103.setUpdDate(new Date());
        ocs0103.setHangmogCode(StringUtils.isEmpty(info.getHangmogCode()) ? null : info.getHangmogCode());
        ocs0103.setHangmogName(StringUtils.isEmpty(info.getHangmogName()) ? null : info.getHangmogName());
        ocs0103.setSlipCode(StringUtils.isEmpty(info.getSlipCode()) ? null : info.getSlipCode());
        ocs0103.setGroupYn(StringUtils.isEmpty(info.getGroupYn()) ? null : info.getGroupYn());
        ocs0103.setPosition(StringUtils.isEmpty(info.getPosition()) ? null : info.getPosition());
        ocs0103.setSeq(seq);
        //Fix bug MED-11995
        //ocs0103.setOrderGubun(StringUtils.isEmpty(info.getOrderGubun()) ? "" : info.getOrderGubun());
        ocs0103.setOrderGubun(StringUtils.isEmpty(info.getOrderGubun()) ? null : info.getOrderGubun());
        ocs0103.setInputControl(StringUtils.isEmpty(info.getInputControl()) ? null : info.getInputControl());
        ocs0103.setJundalTableOut(StringUtils.isEmpty(info.getJundalTableOut()) ? null : info.getJundalTableOut());
        ocs0103.setJundalTableInp(StringUtils.isEmpty(info.getJundalTableInp()) ? null : info.getJundalTableInp());
        ocs0103.setJundalPartOut(StringUtils.isEmpty(info.getJundalPartOut()) ? null : info.getJundalPartOut());
        ocs0103.setJundalPartInp(StringUtils.isEmpty(info.getJundalPartInp()) ? null : info.getJundalPartInp());
        ocs0103.setMovePart(StringUtils.isEmpty(info.getMovePart()) ? null : info.getMovePart());
        ocs0103.setDvTime(StringUtils.isEmpty(info.getDvTime()) ? null : info.getDvTime());
        ocs0103.setOrdDanui(StringUtils.isEmpty(info.getOrdDanui()) ? null : info.getOrdDanui());
        ocs0103.setDefaultBogyongCode(
                StringUtils.isEmpty(info.getDefaultBogyongCode()) ? null : info.getDefaultBogyongCode());
        ocs0103.setSugaYn(StringUtils.isEmpty(info.getSugaYn()) ? null : info.getSugaYn());
        ocs0103.setSgCode(StringUtils.isEmpty(info.getSgCode()) ? null : info.getSgCode());
        if((OrderGubun.C.getValue().equals(info.getOrderGubun()) || OrderGubun.D.getValue().equals(info.getOrderGubun()) 
        		|| OrderGubun.K.getValue().equals(info.getOrderGubun()) || OrderGubun.B.getValue().equals(info.getOrderGubun()))
                && StringUtils.isEmpty(info.getJaeryoCode())){
            ocs0103.setJaeryoCode(info.getHangmogCode());
            ocs0103.setJaeryoYn("Y");
        }else{
            ocs0103.setJaeryoYn(StringUtils.isEmpty(info.getJaeryoYn()) ? null : info.getJaeryoYn());
            ocs0103.setJaeryoCode( StringUtils.isEmpty(info.getJaeryoCode()) ? null : info.getJaeryoCode());
        }
        ocs0103.setHangmogNameInx(StringUtils.isEmpty(info.getHangmogNameInx()) ? null : info.getHangmogNameInx());
        ocs0103.setDisplayYn("Y");
        Date endDate = DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD);
        if (endDate == null) {
            endDate = DateUtil.toDate("99981231", DateUtil.PATTERN_YYMMDD_BLANK);
        }
        ocs0103.setEndDate(endDate);
        ocs0103.setSpecimenYn(StringUtils.isEmpty(info.getSpecimenYn()) ? null : info.getSpecimenYn());
        ocs0103.setSpecimenDefault(StringUtils.isEmpty(info.getSpecimenDefault()) ? null : info.getSpecimenDefault());
        ocs0103.setDefaultPortableYn(
                StringUtils.isEmpty(info.getDefaultPortableYn1()) ? null : info.getDefaultPortableYn1());
        ocs0103.setSpecificComment(StringUtils.isEmpty(info.getSpecificComment()) ? null : info.getSpecificComment());
        ocs0103.setReserYnOut(StringUtils.isEmpty(info.getReserYnOut()) ? null : info.getReserYnOut());
        ocs0103.setReserYnInp(StringUtils.isEmpty(info.getReserYnInp()) ? null : info.getReserYnInp());
        ocs0103.setEmergency(StringUtils.isEmpty(info.getEmergency()) ? null : info.getEmergency());
        ocs0103.setLimitSuryang(CommonUtils.parseDouble(info.getLimitSuryang()));
        ocs0103.setBomYn(StringUtils.isEmpty(info.getBomYn()) ? null : info.getBomYn());
        ocs0103.setReturnYn(StringUtils.isEmpty(info.getReturnYn()) ? null : info.getReturnYn());
        ocs0103.setSubulConvertGubun(
                StringUtils.isEmpty(info.getSubulConvertGubun()) ? null : info.getSubulConvertGubun());
        ocs0103.setWonyoiOrderYn(StringUtils.isEmpty(info.getWonyoiOrderYn()) ? null : info.getWonyoiOrderYn());
        ocs0103.setDefaultWonnaeSayu(
                StringUtils.isEmpty(info.getDefaultWonnaeSayu()) ? null : info.getDefaultWonnaeSayu());
        ocs0103.setAntiCancerYn(StringUtils.isEmpty(info.getAntiCancerYn()) ? null : info.getAntiCancerYn());
        ocs0103.setChisikYn(StringUtils.isEmpty(info.getChisikYn()) ? null : info.getChisikYn());
        ocs0103.setNdayYn(StringUtils.isEmpty(info.getNdayYn()) ? null : info.getNdayYn());
        ocs0103.setMuhyoYn(StringUtils.isEmpty(info.getMuhyoYn()) ? null : info.getMuhyoYn());
        ocs0103.setInvJundalYn(StringUtils.isEmpty(info.getInvJundalYn()) ? null : info.getInvJundalYn());
        ocs0103.setPowderYn(StringUtils.isEmpty(info.getPowderYn()) ? null : info.getPowderYn());
        ocs0103.setRemark(StringUtils.isEmpty(info.getRemark()) ? null : info.getRemark());
        ocs0103.setDefaultDv(CommonUtils.parseDouble(info.getDefaultDv()));
        ocs0103.setDefaultSuryang(CommonUtils.parseDouble(info.getDefaultSuryang()));
        ocs0103.setSgName(info.getSgName());
        ocs0103.setNurseInputYn(StringUtils.isEmpty(info.getNurseInputYn()) ? null : info.getNurseInputYn());
        ocs0103.setSupplyInputYn(StringUtils.isEmpty(info.getSupplyInputYn()) ? null : info.getSupplyInputYn());
        ocs0103.setLimitNalsu(CommonUtils.parseDouble(info.getLimitNalsu()));
        ocs0103.setDefaultWonyoiYn(StringUtils.isEmpty(info.getDefaultWonyoiYn()) ? null : info.getDefaultWonyoiYn());
        ocs0103.setPortableCheck(StringUtils.isEmpty(info.getPortableCheck()) ? null : info.getPortableCheck());
        ocs0103.setPatStatusGr(StringUtils.isEmpty(info.getPatStatusGr()) ? null : info.getPatStatusGr());
        ocs0103.setUpdId(userId);
        ocs0103.setHospCode(hospCode);
        Date startDate = DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD);
        ocs0103.setStartDate(startDate);
        ocs0103.setDefaultJusa(StringUtils.isEmpty(info.getDefaultJusa()) ? null : info.getDefaultJusa());
        ocs0103.setIfInputControl(StringUtils.isEmpty(info.getIfInputControl()) ? null : info.getIfInputControl());
        ocs0103.setResultGubun(StringUtils.isEmpty(info.getResultGubun()) ? null : info.getResultGubun());
        ocs0103.setWonnaeDrgYn(StringUtils.isEmpty(info.getWonnaeDrgYn()) ? null : info.getWonnaeDrgYn());
        // ocs0103.setOutHospBookYn(StringUtils.isEmpty(info.getOutHospBookYn())
        // ? null : info.getOutHospBookYn());

        ocs0103.setCommonOrder(info.getCommonOrder());
        ocs0103.setYjCode(StringUtils.isEmpty(info.getYjCode()) ? null : info.getYjCode());
        ocs0103.setClisProtocolId(StringUtils.isEmpty(protocolId) ? null : protocolId);
        ocs0103.setTrialFlg(StringUtils.isEmpty(info.getTrial()) ? "N" : info.getTrial());
        ocs0103.setModifyFlg(ModifyFlg.INSERT.getValue());
        ocs0103Repository.save(ocs0103);
    }

    private void insertOCS0108(OCS0103U00GrdOCS0108Info info, String userId, Double seq, String hospCode) {
        Ocs0108 ocs0108 = new Ocs0108();
        ocs0108.setSysDate(new Date());
        ocs0108.setSysId(userId);
        ocs0108.setUpdDate(new Date());
        ocs0108.setUpdId(userId);
        ocs0108.setHospCode(hospCode);
        ocs0108.setHangmogCode(StringUtils.isEmpty(info.getHangmogCode()) ? null : info.getHangmogCode());
        ocs0108.setOrdDanui(StringUtils.isEmpty(info.getOrdDanui()) ? null : info.getOrdDanui());
        ocs0108.setSeq(seq);
        ocs0108.setChangeQty1(CommonUtils.parseDouble(info.getSunabGijun()));
        ocs0108.setChangeQty2(CommonUtils.parseDouble(info.getSubulGijun()));
        Date hangmogStartDate = DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);
        ocs0108.setHangmogStartDate(hangmogStartDate);
        ocs0108.setModifyFlg(ModifyFlg.INSERT.getValue());
        ocs0108Repository.save(ocs0108);
    }

    private void insertOCS0115(OCS0103U00GrdOCS0115Info info, String userId, String hospCode) {
        Ocs0115 ocs0115 = new Ocs0115();
        Date startDate = DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD);
        Date endDate = DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD);
        Date hangmogStartDate = DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);

        ocs0115.setSysDate(new Date());
        ocs0115.setSysId(userId);
        ocs0115.setUpdDate(new Date());
        ocs0115.setHangmogCode(StringUtils.isEmpty(info.getHangmogCode()) ? null : info.getHangmogCode());
        ocs0115.setInputPart(StringUtils.isEmpty(info.getInputPart()) ? null : info.getInputPart());
        ocs0115.setInputGwa(StringUtils.isEmpty(info.getInputGwa()) ? null : info.getInputGwa());
        ocs0115.setJundalTableOut(StringUtils.isEmpty(info.getJundalTableOut()) ? null : info.getJundalTableOut());
        ocs0115.setJundalPartOut(StringUtils.isEmpty(info.getJundalPartOut()) ? null : info.getJundalPartOut());
        ocs0115.setMovePart(StringUtils.isEmpty(info.getMovePart()) ? null : info.getMovePart());
        ocs0115.setJundalTableInp(StringUtils.isEmpty(info.getJundalTableInp()) ? null : info.getJundalTableInp());
        ocs0115.setJundalPartInp(StringUtils.isEmpty(info.getJundalPartInp()) ? null : info.getJundalPartInp());
        ocs0115.setUpdId(userId);
        ocs0115.setHospCode(hospCode);
        ocs0115.setStartDate(startDate);
        ocs0115.setEndDate(endDate);
        ocs0115.setHangmogStartDate(hangmogStartDate);
        // ocs0115.setModifyFlg(ModifyFlg.INSERT.getValue());
        ocs0115Repository.save(ocs0115);
    }

    private void insertOCS0113(OCS0103U00GrdOCS0113Info info, String userId, Double seq, String hospCode) {
        Ocs0113 ocs0113 = new Ocs0113();
        Date hangmogStartDate = DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);
        ocs0113.setSysDate(new Date());
        ocs0113.setSysId(userId);
        ocs0113.setUpdDate(new Date());
        ocs0113.setHangmogCode(StringUtils.isEmpty(info.getHangmogCode()) ? null : info.getHangmogCode());
        ocs0113.setSpecimenCode(StringUtils.isEmpty(info.getSpecimenCode()) ? null : info.getSpecimenCode());
        ocs0113.setSeq(seq);
        ocs0113.setDefaultYn(StringUtils.isEmpty(info.getDefaultYn()) ? null : info.getDefaultYn());
        ocs0113.setUpdId(userId);
        ocs0113.setHospCode(hospCode);
        ocs0113.setHangmogStartDate(hangmogStartDate);
        // ocs0113.setModifyFlg(ModifyFlg.INSERT.getValue());
        ocs0113Repository.save(ocs0113);
    }

    private boolean isMappedToAccountingSystem(String hangmogCode, List<String> hospCodes, boolean requiredOcs0103Existed) {
        for (String hospCode : hospCodes) {
            if(!ifs0003Repository.getCommonMapped(hangmogCode, hospCode, requiredOcs0103Existed)) return false;
        }
        return true;
    }
    
    private void insertInv0110(OCS0103U00GrdOCS0103Info info, String userId, String hospCode){
    	Inv0110 inv0110 = new Inv0110();
    	String stockYn = "N";
    	String orderGubun = info.getOrderGubun();
    	Double subulDanga = null;
    	Date startDate = DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD);
    	if((OrderGubun.C.getValue().equals(orderGubun) || OrderGubun.D.getValue().equals(orderGubun) || OrderGubun.K.getValue().equals(orderGubun)
    			&& YesNo.YES.getValue().equals(info.getWonnaeDrgYn()))){
    		stockYn = "Y";
    		subulDanga = new Double("0");
    	}
    	inv0110.setJaeryoCode(info.getHangmogCode());
    	inv0110.setJaeryoName(info.getHangmogName());
    	inv0110.setJaeryoNameInx(info.getHangmogName() + " " + info.getHangmogCode());
    	inv0110.setSubulDanui(info.getOrdDanui());
    	inv0110.setHospCode(hospCode);
    	inv0110.setSysDate(new Date());
    	inv0110.setUpdId(userId);
    	inv0110.setSysId(userId);
    	inv0110.setStockYn(stockYn);
    	inv0110.setModifyFlg("I");
    	inv0110.setSubulDanga(subulDanga);
    	inv0110.setJukyongDate(startDate);
    	inv0110Repository.save(inv0110);
    }
}