package nta.med.service.ihis.handler.nuro;

import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.glossary.UserRole;
import nta.med.core.infrastructure.SessionUserInfo;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.res.Res0102Repository;
import nta.med.data.dao.medi.res.Res0103Repository;
import nta.med.data.dao.medi.res.Res0104Repository;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0102Info;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0103Info;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GrdRES0103ResInfo;
import nta.med.data.model.ihis.nuro.NuroRES0102U00GridDoctorInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;

@Service
@Scope("prototype")
public class NuroRES0102U00GetDataGridViewHandler extends ScreenHandler<NuroServiceProto.NuroRES0102U00GetDataGridViewRequest, NuroServiceProto.NuroRES0102U00GetDataGridViewResponse> {
	private static final Log LOG = LogFactory.getLog(NuroRES0102U00GetDataGridViewHandler.class);
	
	@Resource
	private Res0102Repository res0102Repository;
	
	@Resource
	private Res0103Repository res0103Repository;
	
	@Resource
	private Res0104Repository res0104Repository;
	
	@Override
    public void preHandle(Vertx vertx, String clientId, String sessionId, long contextId, NuroServiceProto.NuroRES0102U00GetDataGridViewRequest request) throws Exception {
		if(UserRole.SUPER_ADMIN.getValue().equals(getUserRole(vertx, sessionId))) {
			setSessionInfo(vertx, sessionId, SessionUserInfo.setSessionUserInfoByUserGroup(request.getHospCode(),
					getLanguage(vertx, sessionId), "", 1));
		}
    }
	
	@Override
	@Transactional(readOnly = true)
	public NuroServiceProto.NuroRES0102U00GetDataGridViewResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			NuroServiceProto.NuroRES0102U00GetDataGridViewRequest request) throws Exception {
        NuroServiceProto.NuroRES0102U00GetDataGridViewResponse.Builder response = NuroServiceProto.NuroRES0102U00GetDataGridViewResponse.newBuilder();
    	String hospCode = request.getHospCode();
    	List<NuroRES0102U00GrdRES0102Info> listNuroRES0102U00GrdRES0102Info = res0102Repository.getNuroRES0102U00GrdRES0102Info(hospCode, request.getDoctor());
    	if (listNuroRES0102U00GrdRES0102Info != null && !listNuroRES0102U00GrdRES0102Info.isEmpty()) {
            for (NuroRES0102U00GrdRES0102Info item : listNuroRES0102U00GrdRES0102Info) {
                NuroModelProto.NuroRES0102U00GrdRES0102Info.Builder info = NuroModelProto.NuroRES0102U00GrdRES0102Info.newBuilder();
                BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
                if (item.getAvgTime() != null) {
                	info.setAvgTime(String.format("%.0f",item.getAvgTime()));
                }
                if (item.getDocResLimit() != null) {
                	info.setDocResLimit(String.format("%.0f",item.getDocResLimit()));
                }
                if (item.getEtcResLimit() != null) {
                	info.setEtcResLimit(String.format("%.0f",item.getEtcResLimit()));
                }
                response.addDataGridRes0102Info(info);
            }
        }
        	
    	List<NuroRES0102U00GrdRES0103Info> listNuroRES0102U00GrdRES0103Info = res0103Repository.getNuroRES0102U00GrdRES0103Info(hospCode, request.getDoctor(), request.getDate());
    	if (listNuroRES0102U00GrdRES0103Info != null && !listNuroRES0102U00GrdRES0103Info.isEmpty()) {
            for (NuroRES0102U00GrdRES0103Info obj : listNuroRES0102U00GrdRES0103Info) {
                NuroModelProto.NuroRES0102U00GrdRES0103Info.Builder builder = NuroModelProto.NuroRES0102U00GrdRES0103Info.newBuilder();
                BeanUtils.copyProperties(obj, builder, getLanguage(vertx, sessionId));
                response.addDataGridRes0103Info(builder);
                
            }
        }
        	
    	List<NuroRES0102U00GrdRES0103ResInfo> listNuroRES0102U00GrdRES0103ResInfo = res0103Repository.getNuroRES0102U00GrdRES0103ResInfo(hospCode, request.getDoctor(), request.getDate());
		if (listNuroRES0102U00GrdRES0103ResInfo != null && !listNuroRES0102U00GrdRES0103ResInfo.isEmpty()) {
            for (NuroRES0102U00GrdRES0103ResInfo obj : listNuroRES0102U00GrdRES0103ResInfo) {
                NuroModelProto.NuroRES0102U00GrdRES0103ResInfo.Builder builder = NuroModelProto.NuroRES0102U00GrdRES0103ResInfo.newBuilder();
                BeanUtils.copyProperties(obj, builder, getLanguage(vertx, sessionId));
                response.addDataGridRes0103ResInfo(builder);
                
            }
        }
        	
    	List<NuroRES0102U00GridDoctorInfo> listNuroRES0102U00GridDoctor = res0104Repository.getNuroRES0102U00GridDoctor(hospCode, request.getDoctor());
    	if (listNuroRES0102U00GridDoctor != null && !listNuroRES0102U00GridDoctor.isEmpty()) {
            for (NuroRES0102U00GridDoctorInfo item : listNuroRES0102U00GridDoctor) {
                NuroModelProto.NuroRES0102U00GridDoctorInfo.Builder info = NuroModelProto.NuroRES0102U00GridDoctorInfo.newBuilder();
                if (!StringUtils.isEmpty(item.getDoctor())) {
                	info.setDoctor(item.getDoctor());
                }
                if (item.getStartDate() != null) {
                	info.setStartDate(DateUtil.toString(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (item.getEndDate() != null) {
                	info.setEndDate(DateUtil.toString(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
                }
                if (!StringUtils.isEmpty(item.getSayu())) {
                	info.setSayu(item.getSayu());
                }

                response.addDataGridDoctorInfo(info);
            }
        }
		return response.build();
	}
}
