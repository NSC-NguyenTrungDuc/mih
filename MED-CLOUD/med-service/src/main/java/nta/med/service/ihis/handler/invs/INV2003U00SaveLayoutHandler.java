package nta.med.service.ihis.handler.invs;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.inv.Inv2003;
import nta.med.core.domain.inv.Inv2004;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.com.ComSeqRepository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.dao.medi.inv.Inv2003Repository;
import nta.med.data.dao.medi.inv.Inv2004Repository;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

/**
 * @author DEV-TiepNM
 */
@Service
@Scope("prototype")
@Transactional
public class INV2003U00SaveLayoutHandler extends ScreenHandler<InvsServiceProto.INV2003U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

    @Resource
    private ComSeqRepository comSeqRepository;
    @Resource
    private Inv2003Repository inv2003Repository;
    @Resource
    private Inv2004Repository inv2004Repository;
    @Resource
    private CommonRepository commonRepository;
    @Resource
    private Inv0102Repository inv0102Repository;

    @Override
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, InvsServiceProto.INV2003U00SaveLayoutRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder updateResponse = SystemServiceProto.UpdateResponse.newBuilder();
        updateResponse.setResult(true);
        String hospCode = getHospitalCode(vertx, sessionId);
        try {
            updateDataToInv2003(vertx, sessionId, request, hospCode);
            if (!updateDataToInv2004(vertx, sessionId, request, hospCode)) {
                updateResponse.setResult(false);
                updateResponse.setMsg("");
            }
        } catch (Exception e) {
            updateResponse.setResult(false);
            updateResponse.setMsg("");
            throw new ExecutionException(updateResponse.build());
        }
        return updateResponse.build();

    }

    private boolean updateDataToInv2004(Vertx vertx, String sessionId, InvsServiceProto.INV2003U00SaveLayoutRequest request, String hospCode) {
        boolean validData = true;
        for (InvsModelProto.INV2003U00GrdINV2004Info inv2004Info : request.getInfo2004List()) {

            String dataRowState = inv2004Info.getRowState();
            if (DataRowState.ADDED.getValue().equals(dataRowState)) {
                Integer count = inv2004Repository.countByHospcodeAndFkinv2003AndJaeryoCode(hospCode,
                        CommonUtils.parseDouble(inv2004Info.getFkinv2003()), inv2004Info.getJaeryoCode());
                if (count > 0) {
                    validData = false;
                    break;
                }
                
                Inv2004 inv2004 = new Inv2004();
                inv2004.setSysId(getUserId(vertx, sessionId));
                inv2004.setSysDate(new Date());
                inv2004.setUpdDate(new Date());
                inv2004.setUpdId(getUserId(vertx, sessionId));
                inv2004.setHospCode(hospCode);
                Double pkinv2004 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2004_SEQ"));
                inv2004.setPkinv2004(pkinv2004);
                inv2004.setFkinv2003(CommonUtils.parseDouble(inv2004Info.getFkinv2003()));
                inv2004.setJaeryoCode(inv2004Info.getJaeryoCode());
                inv2004.setChulgoQty(CommonUtils.parseDouble(inv2004Info.getChulgoQty()));
                inv2004.setChulgoDanga(CommonUtils.parseDouble(inv2004Info.getChulgoDanga()));
                inv2004.setRemark(inv2004Info.getRemark());
                inv2004Repository.save(inv2004);
            } else if (DataRowState.MODIFIED.getValue().equals(dataRowState)) {
                List<Inv2004> inv2004s = inv2004Repository.findByHospCodeAndFkinv2003AndJaeryoCode(hospCode,
                        CommonUtils.parseDouble(inv2004Info.getFkinv2003()), inv2004Info.getJaeryoCode());
                if (!CollectionUtils.isEmpty(inv2004s)) {
                    Inv2004 inv2004 = inv2004s.get(0);
                    inv2004.setChulgoQty(CommonUtils.parseDouble(inv2004Info.getChulgoQty()));
                    inv2004.setChulgoDanga(CommonUtils.parseDouble(inv2004Info.getChulgoDanga()));
                    inv2004.setRemark(inv2004Info.getRemark());
                    inv2004.setUpdDate(new Date());
                    inv2004.setUpdId(getUserId(vertx, sessionId));
                    inv2004Repository.save(inv2004);
                }
            } else if (DataRowState.DELETED.getValue().equals(dataRowState)) {
                List<Inv2004> inv2004s = inv2004Repository.findByHospCodeAndFkinv2003AndJaeryoCode(hospCode,
                        CommonUtils.parseDouble(inv2004Info.getFkinv2003()), inv2004Info.getJaeryoCode());
                if (!CollectionUtils.isEmpty(inv2004s)) {
                    inv2004Repository.delete(inv2004s.get(0));
                }
            }
        }

        return validData;
    }

    private void updateDataToInv2003(Vertx vertx, String sessionId, InvsServiceProto.INV2003U00SaveLayoutRequest request, String hospCode) {
    	List<String> codeNames = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, getLanguage(vertx, sessionId), "INV_IMPORT", "INV_PREFIX");
		String preFixCode = codeNames.size() > 0 ? codeNames.get(0) : "";
        for (InvsModelProto.INV2003U00GrdINV2003Info inv2003Info : request.getInfo2003List()) {
            String dataRowState = inv2003Info.getRowState();
            if (DataRowState.ADDED.getValue().equals(dataRowState)) {
            	String churiSeq = commonRepository.getNextVal("CHURI_SEQ");
            	String exportCode = preFixCode + churiSeq;
                Inv2003 inv2003 = new Inv2003();
                inv2003.setSysId(getUserId(vertx, sessionId));
                inv2003.setSysDate(new Date());
                inv2003.setUpdId(getUserId(vertx, sessionId));
                inv2003.setHospCode(hospCode);
                inv2003.setPkinv2003(CommonUtils.parseDouble(inv2003Info.getPkinv2003()));
                inv2003.setChuriDate(DateUtil.toDate(inv2003Info.getChuriDate(), DateUtil.PATTERN_YYMMDD));
                inv2003.setChuriBuseo(inv2003Info.getChuriBuseo());
                inv2003.setChulgoType(inv2003Info.getChulgoType());
                String seqKey = inv2003Info.getChuriDate().concat("-").concat(inv2003Info.getChuriBuseo()).concat("-").concat(inv2003Info.getChulgoType());
                Double churiSed = comSeqRepository.getMaxSeq(hospCode, "INV2003", "SEQ", seqKey);
                inv2003.setChuriSeq(churiSed);
                inv2003.setJaeryoGubun(inv2003Info.getJaeryoGubun());
                inv2003.setIpchulType(inv2003Info.getIpchulType());
                inv2003.setInOutGubun(inv2003Info.getInOutGubun());
                inv2003.setRemark(inv2003Info.getRemark());
                inv2003.setChuriTime(inv2003Info.getChuriTime().replace(":", ""));
                inv2003.setExportCode(exportCode);
                inv2003Repository.save(inv2003);
            } else if (DataRowState.MODIFIED.getValue().equals(dataRowState)) {
                List<Inv2003> inv2003s = inv2003Repository.findByHospCodeAndPkinv2003(hospCode, CommonUtils.parseDouble(inv2003Info.getPkinv2003()));
                if (!CollectionUtils.isEmpty(inv2003s)) {
                    Inv2003 inv2003 = inv2003s.get(0);
                    inv2003.setRemark(inv2003Info.getRemark());
                    inv2003Repository.save(inv2003);
                }
            } else if (DataRowState.DELETED.getValue().equals(dataRowState)) {
                List<Inv2003> inv2003s = inv2003Repository.findByHospCodeAndPkinv2003(hospCode, CommonUtils.parseDouble(inv2003Info.getPkinv2003()));
                if (!CollectionUtils.isEmpty(inv2003s)) {
                    inv2003Repository.delete(inv2003s.get(0));
                }
            }

        }
    }


}
