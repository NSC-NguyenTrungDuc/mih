package nta.med.service.integration.cpls;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.CplsServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class CPL2010U01grdTubeTest extends MessageRequestTest{

	@Test
	public void Test() throws Exception{
		CplsServiceProto.CPL2010U01grdTubeRequest request = CplsServiceProto.CPL2010U01grdTubeRequest.newBuilder()
				.setBunho("000003488")
				.setJubsuDate("2014/05/22")
				.setJubsuTime("1000")
				.setReserDate("2016/12/27")
				.setReserYn("Y")
				.setQuerySqlIndex("1")
				.build();
		sentRequestToMedApp(request, CplsServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
