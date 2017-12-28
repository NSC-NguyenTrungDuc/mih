package nta.med.service.ihis.handler.nuro;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.bas.Bas0260Repository;
import nta.med.data.dao.medi.nur.Nur0102Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service
@Scope("prototype")
public class InitializeComboListItemHandler extends ScreenHandler<NuroServiceProto.InitializeComboListItemRequest, NuroServiceProto.InitializeComboListItemResponse> {
	private static final Log LOG = LogFactory.getLog(InitializeComboListItemHandler.class);
	@Resource
	private Bas0260Repository bas0260Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Nur0102Repository nur0102Repository;

	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.InitializeComboListItemResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.InitializeComboListItemRequest request) throws Exception {
		NuroServiceProto.InitializeComboListItemResponse.Builder response = NuroServiceProto.InitializeComboListItemResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		Date comingDate = DateUtil.getDateTime(new Date(), DateUtil.PATTERN_YYMMDD);
		List<ComboListItemInfo> listComboDepartment = bas0260Repository.getComboDepartmentItemInfo(language, hospCode, comingDate, true);
    	if (listComboDepartment != null && !listComboDepartment.isEmpty()) {
            for (ComboListItemInfo obj : listComboDepartment) {
                CommonModelProto.ComboListItemInfo.Builder comboInfo = CommonModelProto.ComboListItemInfo.newBuilder();
                if(!StringUtils.isEmpty(obj.getCode())){
                	comboInfo.setCode(obj.getCode());
                }
                if(!StringUtils.isEmpty(obj.getCodeName())){
                	comboInfo.setCodeName(obj.getCodeName());

                }
                response.addComboDepartmentItem(comboInfo);
            }
        }
    	
    	if(request.getCodeType() != null && !"".equals(request.getCodeType())){	
    		List<ComboListItemInfo> listComboType = bas0102Repository.getNuroReceptionTypeList(language, hospCode, request.getCodeType(), false);
        	if (listComboType != null && !listComboType.isEmpty()) {
                for (ComboListItemInfo item : listComboType) {
                    CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                    if(!StringUtils.isEmpty(item.getCode())){
                    	info.setCode(item.getCode());
                    }
                    if(!StringUtils.isEmpty(item.getCodeName())){
                        info.setCodeName(item.getCodeName());
                    }
                    response.addComboTypeItem(info);
                }
            }
    	}
    	
    	if(request.getComboTimeType() != null && !"".equals(request.getComboTimeType())){	 
        	List<ComboListItemInfo> listObject = nur0102Repository.getNuroComboTime(language, hospCode, request.getComboTimeType(), false);
        	if (listObject != null && !listObject.isEmpty()) {
                for (ComboListItemInfo obj : listObject) {
                    CommonModelProto.ComboListItemInfo.Builder nuroComboTimeInfo = CommonModelProto.ComboListItemInfo.newBuilder();
                    if (!StringUtils.isEmpty(obj.getCode())) {
                    	nuroComboTimeInfo.setCode(obj.getCode());
                    }
                    if (!StringUtils.isEmpty(obj.getCodeName())) {
                    	nuroComboTimeInfo.setCodeName(obj.getCodeName());
                    }
                    response.addComboTimeItem(nuroComboTimeInfo);
                }
            }
        }
    	if(request.getCodeTypeCboTel() != null && !"".equals(request.getCodeTypeCboTel())){
    		List<ComboListItemInfo> listComboTelType = bas0102Repository.getNuroReceptionTypeList(language, hospCode, request.getCodeTypeCboTel(), false);
        	if (listComboTelType != null && !listComboTelType.isEmpty()) {
                for (ComboListItemInfo item : listComboTelType) {
                    CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                    if(!StringUtils.isEmpty(item.getCode())){
                    	info.setCode(item.getCode());
                    }
                    if(!StringUtils.isEmpty(item.getCodeName())){
                    	info.setCodeName(item.getCodeName());
                    }
                    response.addComboTelItem(info);
                }
            }
    	}
    	
    	if(request.getCodeTypeChojae() != null && !"".equals(request.getCodeTypeChojae())){
    		List<ComboListItemInfo> listComboChojae = bas0102Repository.getNuroReceptionTypeList(language, hospCode, request.getCodeTypeChojae(), false);
        	if (listComboChojae != null && !listComboChojae.isEmpty()) {
                for (ComboListItemInfo item : listComboChojae) {
                    CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
                    if(!StringUtils.isEmpty(item.getCode())){
                    	info.setCode(item.getCode());
                    }
                    if(!StringUtils.isEmpty(item.getCodeName())){
                    	info.setCodeName(item.getCodeName());
                    }
                    response.addComboChojaeItem(info);
                }
            }
    	}
		return response.build();
	}
}
