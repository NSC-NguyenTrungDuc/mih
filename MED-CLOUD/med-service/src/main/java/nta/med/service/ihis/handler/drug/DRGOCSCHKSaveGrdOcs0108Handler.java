package nta.med.service.ihis.handler.drug;

import java.util.Date;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs0108;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.ModifyFlg;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0108Repository;
import nta.med.service.ihis.proto.DrugServiceProto;
import nta.med.service.ihis.proto.DrugServiceProto.DRGOCSCHKSaveGrdOcs0108Request;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.DrugModelProto.DRGOCSCHKgrdOCS0108Info;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Transactional
@Service                                                                                                          
@Scope("prototype")
public class DRGOCSCHKSaveGrdOcs0108Handler  extends ScreenHandler<DrugServiceProto.DRGOCSCHKSaveGrdOcs0108Request, SystemServiceProto.UpdateResponse>{
	private static final Log LOGGER = LogFactory.getLog(DRGOCSCHKSaveGrdOcs0108Handler.class);                                    
	@Resource                                                                                                       
	private Ocs0108Repository ocs0108Repository;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			DRGOCSCHKSaveGrdOcs0108Request request) throws Exception {
		String hospCode = getHospitalCode(vertx, sessionId);
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		if(CollectionUtils.isEmpty(request.getListInfoList())){
			response.setResult(false);
		}else{
			for(DRGOCSCHKgrdOCS0108Info info : request.getListInfoList()){
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
	                boolean result = insertOCS0108(info, getUserId(vertx, sessionId), seq, hospCode);
	                response.setResult(result);
	            } else if(info.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(updateOCS0103U00(info, getUserId(vertx, sessionId), hospCode));
				} else if (DataRowState.DELETED.getValue().equals(info.getRowState())) {
					response.setResult(ocs0108Repository.deleteOCS0108U00Execute(hospCode, info.getHangmogCode(), hangmogStartDate,
	                        info.getOrdDanui()) > 0 ? true : false);
	            }
			}
		}			
		return response.build();
	}
	
	private boolean insertOCS0108(DRGOCSCHKgrdOCS0108Info info, String userId, Double seq, String hospCode) {
        Ocs0108 ocs0108 = new Ocs0108();
        ocs0108.setSysDate(new Date());
        ocs0108.setSysId(userId);
        ocs0108.setUpdDate(new Date());
        ocs0108.setUpdId(userId);
        ocs0108.setHospCode(hospCode);
        ocs0108.setHangmogCode(StringUtils.isEmpty(info.getHangmogCode()) ? null : info.getHangmogCode());
        ocs0108.setOrdDanui(StringUtils.isEmpty(info.getOrdDanui()) ? null : info.getOrdDanui());
        ocs0108.setSeq(seq);
        ocs0108.setChangeQty1(CommonUtils.parseDouble(info.getChangeQty1()));
        ocs0108.setChangeQty2(CommonUtils.parseDouble(info.getChangeQty2()));
        Date hangmogStartDate = DateUtil.toDate(info.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);
        ocs0108.setHangmogStartDate(hangmogStartDate);
        ocs0108.setModifyFlg(ModifyFlg.INSERT.getValue());
        ocs0108Repository.save(ocs0108);
        return true;
    }
	
	public boolean updateOCS0103U00(DRGOCSCHKgrdOCS0108Info item, String userId, String hospCode){
		Date hangmogStartDate = DateUtil.toDate(item.getHangmogStartDate(), DateUtil.PATTERN_YYMMDD);
		if(ocs0108Repository.updateOCS0103U00(hospCode, CommonUtils.parseDouble(item.getChangeQty1()),
                CommonUtils.parseDouble(item.getChangeQty2()), userId, ModifyFlg.UPDATE.getValue(),
                item.getHangmogCode(), hangmogStartDate, item.getOrdDanui()) > 0){
			return true;
		}else{
			return false;
		}
	}
}
