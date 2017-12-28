package nta.med.service.ihis.handler.nuri;

import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.domain.nur.Nur0110;
import nta.med.core.domain.nur.Nur0111;
import nta.med.core.domain.nur.Nur0112;
import nta.med.core.domain.nur.Nur0113;
import nta.med.core.domain.nur.Nur0114;
import nta.med.core.domain.nur.Nur0115;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.nur.Nur0110Repository;
import nta.med.data.dao.medi.nur.Nur0111Repository;
import nta.med.data.dao.medi.nur.Nur0112Repository;
import nta.med.data.dao.medi.nur.Nur0113Repository;
import nta.med.data.dao.medi.nur.Nur0114Repository;
import nta.med.data.dao.medi.nur.Nur0115Repository;
import nta.med.service.ihis.proto.NuriModelProto;
import nta.med.service.ihis.proto.NuriServiceProto;
import nta.med.service.ihis.proto.NuriServiceProto.NUR0110U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class NUR0110U00SaveLayoutHandler
		extends ScreenHandler<NuriServiceProto.NUR0110U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	@Resource
	private Nur0110Repository nur0110Repository;
	
	@Resource
	private Nur0111Repository nur0111Repository;
	
	@Resource
	private Nur0112Repository nur0112Repository;
	
	@Resource
	private Nur0113Repository nur0113Repository;
	
	@Resource
	private Nur0114Repository nur0114Repository;
	
	@Resource
	private Nur0115Repository nur0115Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			NUR0110U00SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getUserId();
		
		List<NuriModelProto.NUR0110U00GrdNUR0110Info> grd0110 = request.getGrd0110List();
		List<NuriModelProto.NUR0110U00GrdNUR0111Info> grd0111 = request.getGrd0111List();
		List<NuriModelProto.NUR0110U00GrdNUR0112Info> grd0112 = request.getGrd0112List();
		List<NuriModelProto.NUR0110U00GrdNUR0113Info> grd0113 = request.getGrd0113List();
		List<NuriModelProto.NUR0110U00GrdNUR0114Info> grd0114 = request.getGrd0114List();
		List<NuriModelProto.NUR0110U00GrdNUR0115Info> grd0115 = request.getGrd0115List();
		List<NuriModelProto.NUR0110U00GrdNUR01152Info> grd01152 = request.getGrd01152List();
		
		handleGrd0110(hospCode, userId, grd0110);
		
		handleGrd0111(hospCode, userId, grd0111);
		
		handleGrd0112(hospCode, userId, grd0112);
		
		handleGrd0113(hospCode, userId, grd0113);
		
		handleGrd0114(hospCode, userId, grd0114);
		
		handleGrd0115(hospCode, userId, grd0115);
		
		handleGrd01152(hospCode, userId, grd01152);
		
		response.setResult(true);
		return response.build();
	}
	
	private boolean handleGrd0110(String hospCode, String userId, List<NuriModelProto.NUR0110U00GrdNUR0110Info> grd0110){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0110U00GrdNUR0110Info info : grd0110) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0110 nur0110 = new Nur0110();
				nur0110.setSysDate(sysDate);
				nur0110.setSysId(userId);
				nur0110.setUpdDate(sysDate);
				nur0110.setUpdId(userId);
				nur0110.setHospCode(hospCode);
				nur0110.setNurGrCode(info.getNurGrCode());
				nur0110.setNurGrName(info.getNurGrName());
				nur0110.setVald("Y");
				nur0110.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0110.setMent(info.getMent());
				
				nur0110Repository.save(nur0110);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0110Repository.updateByHospCodeNurGrCode(userId, info.getNurGrName(), info.getVald(),
						info.getSortKey(), info.getMent(), hospCode, info.getNurGrCode());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0110Repository.updateValByHospCodeNurGrCode(userId, "N", hospCode, info.getNurGrCode());
			}
		}
		
		return true;
	}

	private boolean handleGrd0111(String hospCode, String userId, List<NuriModelProto.NUR0110U00GrdNUR0111Info> grd0111){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0110U00GrdNUR0111Info info : grd0111) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0111 nur0111 = new Nur0111();
				nur0111.setSysDate(sysDate);
				nur0111.setSysId(userId);
				nur0111.setUpdDate(sysDate);
				nur0111.setNurGrCode(info.getNurGrCode());
				nur0111.setNurMdCode(info.getNurMdCode());
				nur0111.setNurMdName(info.getNurMdName());
				nur0111.setJisiOrderGubun(info.getJisiOrderGubun());
				nur0111.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0111.setMent(info.getMent());
				nur0111.setVald("Y");
				nur0111.setJisiGubun(info.getJisiGubun());
				nur0111.setCntPerhourYn(info.getCntPerhourYn());
				nur0111.setCntPerdayYn(info.getCntPerdayYn());
				nur0111.setActDayYn(info.getActDayYn());
				nur0111.setFrenchYn(info.getFrenchYn());
				nur0111.setActDq1Yn(info.getActDq1Yn());
				nur0111.setActDq2Yn(info.getActDq2Yn());
				nur0111.setActDq3Yn(info.getActDq3Yn());
				nur0111.setActDq4Yn(info.getActDq4Yn());
				nur0111.setActTimeYn(info.getActTimeYn());
				nur0111.setDirectContYn(info.getDirectContYn());
				nur0111.setActingYn(info.getActingYn());
				nur0111.setWorklistDispYn(info.getWorklistDispYn());
				nur0111.setUpdId(userId);
				nur0111.setHospCode(hospCode);
				nur0111.setJisiContinueYn(info.getJisiContinueYn());
				
				nur0111Repository.save(nur0111);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0111Repository.updateByHospCodeNurGrCodeNurMdCode(userId, info.getNurMdName(),
						CommonUtils.parseDouble(info.getSortKey()), info.getMent(), info.getVald(), info.getJisiGubun(),
						info.getCntPerhourYn(), info.getCntPerdayYn(), info.getActDayYn(), info.getFrenchYn(),
						info.getActDq1Yn(), info.getActDq2Yn(), info.getActDq3Yn(), info.getActDq4Yn(),
						info.getActTimeYn(), info.getDirectContYn(), info.getActingYn(), info.getWorklistDispYn(),
						info.getJisiOrderGubun(), info.getJisiContinueYn(), hospCode, info.getNurGrCode(),
						info.getNurMdCode());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0111Repository.updateValdByHospCodeNurGrCodeNurMdCode(userId, "N", hospCode, info.getNurGrCode(), info.getNurMdCode());
			}
		}
		
		return true;
	}
	
	private boolean handleGrd0112(String hospCode, String userId, List<NuriModelProto.NUR0110U00GrdNUR0112Info> grd0112){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0110U00GrdNUR0112Info info : grd0112) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0112 nur0112 = new Nur0112();
				nur0112.setSysDate(sysDate);
				nur0112.setSysId(userId);
				nur0112.setUpdDate(sysDate);
				nur0112.setUpdId(userId);
				nur0112.setHospCode(hospCode);
				nur0112.setNurGrCode(info.getNurGrCode());
				nur0112.setNurMdCode(info.getNurMdCode());
				nur0112.setNurSoCode(info.getNurSoCode());
				nur0112.setNurSoName(info.getNurSoName().trim());
				nur0112.setVald("Y");
				nur0112.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0112.setMent(info.getMent());
				
				nur0112Repository.save(nur0112);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0112Repository.updateByHospCodeNurGrCodeNurMdCodeNurSoCode(userId, info.getNurSoName(),
						info.getVald(), CommonUtils.parseDouble(info.getSortKey()), info.getMent(), hospCode,
						info.getNurGrCode(), info.getNurMdCode(), info.getNurSoCode());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0112Repository.updateValdByHospCodeNurGrCodeNurMdCodeNurSoCode(userId, "N", hospCode,
						info.getNurGrCode(), info.getNurMdCode(), info.getNurSoCode());
			}
		}
		
		return true;
	}
	
	private boolean handleGrd0113(String hospCode, String userId, List<NuriModelProto.NUR0110U00GrdNUR0113Info> grd0113){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0110U00GrdNUR0113Info info : grd0113) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0113 nur0113 = new Nur0113();
				nur0113.setSysDate(sysDate);
				nur0113.setSysId(userId);
				nur0113.setUpdDate(sysDate);
				nur0113.setUpdId(userId);
				nur0113.setHospCode(hospCode);
				nur0113.setNurGrCode(info.getNurGrCode());
				nur0113.setNurMdCode(info.getNurMdCode());
				nur0113.setNurActCode(info.getNurActCode());
				nur0113.setNurActName(info.getNurActName().trim());
				nur0113.setVald("Y");
				nur0113.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0113.setMent(info.getMent());
				
				nur0113Repository.save(nur0113);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0113Repository.updateByHospCodeNurGrCodeNurMdCodeNurActCode(userId, info.getNurActName(),
						info.getVald(), CommonUtils.parseDouble(info.getSortKey()), info.getMent(), hospCode,
						info.getNurGrCode(), info.getNurMdCode(), info.getNurActCode());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0113Repository.updateValdByHospCodeNurGrCodeNurMdCodeNurActCode(userId, "N", hospCode,
						info.getNurGrCode(), info.getNurMdCode(), info.getNurActCode());
			}
		}
		
		return true;
	}
	
	private boolean handleGrd0114(String hospCode, String userId, List<NuriModelProto.NUR0110U00GrdNUR0114Info> grd0114){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0110U00GrdNUR0114Info info : grd0114) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Nur0114 nur0114 = new Nur0114();
				nur0114.setSysDate(sysDate);  
				nur0114.setSysId(userId);     
				nur0114.setUpdDate(sysDate);  
				nur0114.setUpdId(userId);     
				nur0114.setHospCode(hospCode);
				nur0114.setNurGrCode(info.getNurGrCode());
				nur0114.setNurMdCode(info.getNurMdCode());
				nur0114.setNurSoCode(info.getNurSoCode());
				nur0114.setNurSoName(info.getNurSoName().trim());
				nur0114.setVald("Y");
				nur0114.setSortKey(CommonUtils.parseDouble(info.getSortKey()));
				nur0114.setMent(info.getMent());
				
				nur0114Repository.save(nur0114);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0114Repository.updateByHospCodeNurGrCodeNurMdCodeNurSoCode(userId, info.getNurSoName(),
						info.getVald(), CommonUtils.parseDouble(info.getSortKey()), info.getMent(), hospCode,
						info.getNurGrCode(), info.getNurMdCode(), info.getNurSoCode());
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0114Repository.updateValdByHospCodeNurGrCodeNurMdCodeNurSoCode(userId, "N", hospCode,
						info.getNurGrCode(), info.getNurMdCode(), info.getNurSoCode());
			}
		}
		
		return true;
	}

	private boolean handleGrd0115(String hospCode, String userId, List<NuriModelProto.NUR0110U00GrdNUR0115Info> grd0115){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0110U00GrdNUR0115Info info : grd0115) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Double seq = nur0115Repository.getNextSeqNur0115(hospCode, info.getNurGrCode(), info.getNurMdCode(), info.getNurSoCode());
				
				Nur0115 nur0115 = new Nur0115();
				nur0115.setSysDate(sysDate);              
				nur0115.setSysId(userId);                 
				nur0115.setUpdDate(sysDate);              
				nur0115.setUpdId(userId);                 
				nur0115.setHospCode(hospCode);            
				nur0115.setNurGrCode(info.getNurGrCode());
				nur0115.setNurMdCode(info.getNurMdCode());
				nur0115.setNurSoCode(info.getNurSoCode());
				nur0115.setHangmogCode(info.getHangmogCode());
				nur0115.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
				nur0115.setDv(CommonUtils.parseDouble(info.getDv()));
				nur0115.setDvTime(info.getDvTime());
				nur0115.setNalsu(CommonUtils.parseDouble(info.getNalsu()));
				nur0115.setBogyongCode(info.getBogyongCode());
				nur0115.setJusaCode(info.getJusaCode());
				nur0115.setOrdDanui(info.getOrdDanui());
				nur0115.setBomSourceKey(info.getBomSourceKey());
				nur0115.setBomYn(info.getBomYn());
				nur0115.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				nur0115.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
				nur0115.setSeq(seq);
				nur0115.setJusaSpdGubun(info.getJusaSpdGubun());
				
				nur0115Repository.save(nur0115);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0115Repository.updateByHospCodeNurGrCodeNurMdCodeNurSoCodeSeq(userId, info.getHangmogCode(),
						CommonUtils.parseDouble(info.getSuryang()), CommonUtils.parseDouble(info.getDv()),
						info.getDvTime(), CommonUtils.parseDouble(info.getNalsu()), info.getBogyongCode(),
						info.getJusaCode(), info.getJusaSpdGubun(), info.getOrdDanui(), info.getBomSourceKey(),
						DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD),
						DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD), hospCode, info.getNurGrCode(),
						info.getNurMdCode(), info.getNurSoCode(), CommonUtils.parseDouble(info.getSeq()));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0115Repository.deleteByHospCodeNurGrCodeNurMdCodeNurSoCodeSeq(hospCode, info.getNurGrCode(),
						info.getNurMdCode(), info.getNurSoCode(), CommonUtils.parseDouble(info.getSeq()));
			}
		}
		
		return true;
	}
	
	private boolean handleGrd01152(String hospCode, String userId, List<NuriModelProto.NUR0110U00GrdNUR01152Info> grd0115){
		Date sysDate = Calendar.getInstance().getTime();
		
		for (NuriModelProto.NUR0110U00GrdNUR01152Info info : grd0115) {
			if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
				Double seq = nur0115Repository.getNextSeqNur0115(hospCode, info.getNurGrCode(), info.getNurMdCode(), info.getNurSoCode());
				
				Nur0115 nur0115 = new Nur0115();
				nur0115.setSysDate(sysDate);              
				nur0115.setSysId(userId);                 
				nur0115.setUpdDate(sysDate);              
				nur0115.setUpdId(userId);                 
				nur0115.setHospCode(hospCode);            
				nur0115.setNurGrCode(info.getNurGrCode());
				nur0115.setNurMdCode(info.getNurMdCode());
				nur0115.setNurSoCode(info.getNurSoCode());
				nur0115.setHangmogCode(info.getHangmogCode());
				nur0115.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
				nur0115.setDv(null);
				nur0115.setDvTime(null);
				nur0115.setNalsu(CommonUtils.parseDouble(info.getNalsu()));
				nur0115.setBogyongCode(info.getBogyongCode());
				nur0115.setJusaCode(null);
				nur0115.setOrdDanui(info.getOrdDanui());
				nur0115.setBomSourceKey(info.getBomSourceKey());
				nur0115.setBomYn(info.getBomYn());
				nur0115.setStartDate(DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD));
				nur0115.setEndDate(DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD));
				nur0115.setSeq(seq);
				nur0115.setJusaSpdGubun(null);
				
				nur0115Repository.save(nur0115);
			}
			else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
				nur0115Repository.updateByHospCodeNurGrCodeNurMdCodeNurSoCodeSeq(userId, info.getHangmogCode(),
						CommonUtils.parseDouble(info.getSuryang()), null,
						null, CommonUtils.parseDouble(info.getNalsu()), info.getBogyongCode(),
						null, null, info.getOrdDanui(), info.getBomSourceKey(),
						DateUtil.toDate(info.getStartDate(), DateUtil.PATTERN_YYMMDD),
						DateUtil.toDate(info.getEndDate(), DateUtil.PATTERN_YYMMDD), hospCode, info.getNurGrCode(),
						info.getNurMdCode(), info.getNurSoCode(), CommonUtils.parseDouble(info.getSeq()));
			}
			else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
				nur0115Repository.deleteByHospCodeNurGrCodeNurMdCodeNurSoCodeSeq(hospCode, info.getNurGrCode(),
						info.getNurMdCode(), info.getNurSoCode(), CommonUtils.parseDouble(info.getSeq()));
			}
		}
		
		return true;
	}
}
