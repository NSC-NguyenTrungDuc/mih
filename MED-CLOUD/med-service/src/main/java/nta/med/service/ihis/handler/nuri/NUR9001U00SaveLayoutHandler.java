package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur9001;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.inp.Inp1001Repository;
import nta.med.data.dao.medi.nur.Nur9001Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service                                                                                                          
@Scope("prototype")
public class NUR9001U00SaveLayoutHandler extends ScreenHandler<NuriServiceProto.NUR9001U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {   
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Inp1001Repository inp1001Repository;
	
	@Resource
	private Nur9001Repository nur9001Repository;
	
	@Override
	@Transactional
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NuriServiceProto.NUR9001U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		Date sysDate = Calendar.getInstance().getTime();
		
		List<NuriModelProto.NUR9001U00grdNur9001Info> infos = request.getGrdNur9001List();
		
		for (NuriModelProto.NUR9001U00grdNur9001Info info : infos) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				String strPknur9001 = StringUtils.isEmpty(info.getPknur9001())
						? commonRepository.getNextVal("NUR9001_SEQ") : info.getPknur9001();
				Double pknur9001 = CommonUtils.parseDouble(strPknur9001);
				
				Double pkinp1001 = CommonUtils.parseDouble(info.getFkinp1001());
				if(pkinp1001 == null){
					pkinp1001 = inp1001Repository.getPkinp1001ByHospCodeBunhoJaewonFlagCancelYn(hospCode,
							info.getBunho());
				}
				
				Nur9001 nur9001 = new Nur9001();
				nur9001.setSysDate(sysDate);
				nur9001.setSysId(userId);
				nur9001.setUpdDate(sysDate);
				nur9001.setUpdId(userId);
				nur9001.setHospCode(hospCode);
				nur9001.setPknur9001(pknur9001);
				nur9001.setFkinp1001(pkinp1001);
				nur9001.setBunho(info.getBunho());
				nur9001.setRecordDate(DateUtil.toDate(info.getRecordDate(), DateUtil.PATTERN_YYMMDD));
				nur9001.setRecordTime(info.getRecordTime());
				nur9001.setSoapGubun(info.getSoapGubun());
				nur9001.setRecordContents(info.getRecordContents());
				nur9001.setNurPlanJin(info.getNurPlanJin());
				nur9001.setRecordUser(StringUtils.isEmpty(info.getRecordUser()) ? userId : info.getRecordUser());
				nur9001.setVald(StringUtils.isEmpty(info.getVald()) ? "Y" : info.getVald());
				nur9001.setDcYn(StringUtils.isEmpty(info.getDcYn()) ? "N" : info.getDcYn());
				nur9001.setDcUser(info.getDcUser());
				nur9001.setMayakUseYn(info.getMayakUseYn());
				nur9001.setFknur4001(CommonUtils.parseDouble(info.getFknur4001()));
				
				nur9001Repository.save(nur9001);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur9001Repository.updateByHospCodePknur9001(userId,
						DateUtil.toDate(info.getRecordDate(), DateUtil.PATTERN_YYMMDD), info.getRecordTime(),
						info.getSoapGubun(), info.getRecordContents(), info.getNurPlanJin(), info.getRecordUser(),
						info.getDcYn(), info.getDcUser(), info.getMayakUseYn(),
						CommonUtils.parseDouble(info.getFknur4001()), hospCode,
						CommonUtils.parseDouble(info.getPknur9001()));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur9001Repository.updateValdByHospCodePknur9001(hospCode, CommonUtils.parseDouble(info.getPknur9001()));
			}
		}
		
		response.setResult(true);
		return response.build();
	}
}
